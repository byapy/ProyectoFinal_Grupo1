using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MovAnimacionesArmas : MonoBehaviour
{
    public static MovAnimacionesArmas Instance;
    public CharacterController Controller;
    public float Speed;
    public float SpeedWalk;
    public float SpeedRun;


    public float VelocitySmooth = 0.1f;
    public float SensivitySmooth;

    public Transform cam;

    public Vector3 VelocidadGravedad;
    public float gravedad = -9.81f;

    public Transform GroundCheck;
    public float GroundDistance;
    //public float GroundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded, isGround;

    public float HeightJump;

    public Animator animator;
    public bool isJump;

    //Para calcular cuántos metros está cayendo el personaje
    public bool isFalling;
    public float DistanciaRecorrida, TiempoEnElAire;

    public GameObject EsferaAtaque;
    public GameObject EsferaLaza;
    public GameObject EsferaEspada;

    public bool ArmaLanza;
    public bool ArmaEspada;
    public bool ArmaMosquete;


    //Abajo son variables de armas
    public GameObject personajeSinArma;
    public GameObject personajeConLanza;
    public GameObject personajeConEspada;
    public GameObject personajeMosquete;

    public InstanciaBala instanciaBala;

    public float tiempoInactivoParaRegresar;
    public float tiempoUltimoUso;

    public GameObject ParticulaCambioArma;


    //public Animator AnimatorNpc;
    public static bool enConversacion;

    //Variable de audio changeWeappon
    public AudioClip ClipCambioArma;
    public AudioSource Source;

    public static bool Teletransporting, IsPaused, InCutscene;

    //Cámaras de Primera y Tercera persona
    bool EnPrimeraPersona;

    [Header("Cámaras disponibles")]
    [SerializeField] GameObject CamaraTP;
    [SerializeField] GameObject CamaraFP;



    private void Awake()
    {
        Instance = this;

    }

    void Start()
    {
        ActivarPersonajeSinArma();

        if (!string.IsNullOrEmpty(SceneData.spawnPoint))
        {
            GameObject spawnpoint = GameObject.Find(SceneData.spawnPoint);

            if (spawnpoint != null)
            {
                transform.position = spawnpoint.transform.position;
                transform.rotation = spawnpoint.transform.rotation;
            }
            else
            {
                Debug.LogWarning("No se encontró el punto de aparición: " + SceneData.spawnPoint);
            }
        }
    }

    void Update()
    {
        if (IsPaused) return;
        

        if (StatsPlayer.IsAlive)
            { 
                /*if(Input.GetKeyDown(KeyCode.Escape))
                {
                    ControlScenes.Instance.MenuPausa();
                }*/

                if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
                {
                    if (ArmaLanza)
                    {
                        ActivarPersonajeLanza();
                        ArmaLanza = false;
                    }
                    else
                    {
                        ActivarPersonajeLanza();
                        ArmaLanza = true;
                        ArmaEspada = false;
                        ArmaMosquete = false;

                        Instantiate(ParticulaCambioArma, transform.position, Quaternion.identity);
                        Source.PlayOneShot(ClipCambioArma);
                    }
                }
                else if ((Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))&& StatsPlayer.TieneEspada)
                {
                    if (ArmaEspada)
                    {
                        ActivarPersonajeEspada();
                        ArmaEspada = false;
                    }
                    else
                    {
                        ActivarPersonajeEspada();
                        ArmaLanza = false;
                        ArmaEspada = true;
                        ArmaMosquete = false;
                        Instantiate(ParticulaCambioArma, transform.position, Quaternion.identity);
                        Source.PlayOneShot(ClipCambioArma);
                    }
                }
                else if ((Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) && StatsPlayer.TieneMosquete)
                {
                    if (ArmaMosquete)
                    {
                        ActivarPersonajeMosquete();
                        ArmaMosquete = false;
                    }
                    else
                    {
                        ActivarPersonajeMosquete();
                        ArmaLanza = false;
                        ArmaEspada = false;
                        ArmaMosquete = true;
                        Instantiate(ParticulaCambioArma, transform.position, Quaternion.identity);
                        Source.PlayOneShot(ClipCambioArma);
                    }
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    ActivarPersonajeSinArma();
                    CamaraFP.SetActive(false);
                    CamaraTP.SetActive(true);


                }

                if(Input.GetKeyDown(KeyCode.Z))
                {
                    StatsPlayer.Instance.UsarPocion("vida");
                    //vida
                }
                if(Input.GetKeyDown(KeyCode.X))
                {
                    StatsPlayer.Instance.UsarPocion("defensa");

                    //defensa
                }
                if (Input.GetKeyDown(KeyCode.C))
                {
                    StatsPlayer.Instance.UsarPocion("ataque");
                    //ataqu
                }


                if (Time.time - tiempoUltimoUso > tiempoInactivoParaRegresar)
                {
                    ActivarPersonajeSinArma();
                    ArmaMosquete = false;//para que no reconozca la bala
                }

                if (!InCutscene) 
                { 
                    Movimiento();
                    Salto();
                    Ataque();

                    DispararMosquete();
                    EstaCayendo();
                }
            }
        else
        {
            animator.SetBool("IsAlive", false);
        }
        
        /*else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ControlScenes.Instance.Continuar();
            }
        }*/
    }
    void Movimiento()
    {

        float Movx = Input.GetAxis("Horizontal");
        float Movz = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(Movx, 0, Movz).normalized;
        float Magnitud = Mathf.Clamp01(direction.magnitude);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            Speed = SpeedRun;
            Magnitud /= 0.5f;
        }
        else
        {
            Speed = SpeedWalk;
        }

        animator.SetFloat("Input Magnitude", Magnitud, 0.05f, Time.deltaTime);
        
        var ScriptFPS = GetComponent<FPSCharacterCtrl>();

        if (!EnPrimeraPersona)
        {
            ScriptFPS.enabled = false;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;//detecta el agunlo
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref SensivitySmooth, VelocitySmooth);//agrega el suavizado
                transform.rotation = Quaternion.Euler(0, angle, 0);//el personaje girara

                Vector3 movDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; //sumara el vector de antes mas el giro de la camara
                Controller.Move(movDir.normalized * Speed * Time.deltaTime);
            }
        }
        else
        {
            ScriptFPS.enabled = true;
        }
    }

    void EstaCayendo()
    {
        if (isFalling)
        {
            DistanciaRecorrida = (TiempoEnElAire * VelocidadGravedad.y) / 2.3f;
        }


    }

    void Salto()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, groundMask);

        if (isGrounded && VelocidadGravedad.y < 0)
        {
            VelocidadGravedad.y = -9.8f;
            animator.SetBool("isGrounded", true);
            isGround = true;
            animator.SetBool("isJumping", false);
            isJump = false;


            //Para calcular daño de las caidas

            if ((DistanciaRecorrida * -1) > 5f)
            {
                float FallDamage = (95f * ((DistanciaRecorrida*-1) - 10f))/30f + 5f;
                StatsPlayer.Instance.ReceivedDamage(FallDamage);
            }

            animator.SetBool("isFalling", false);
            isFalling = false;
            DistanciaRecorrida = 0;
            TiempoEnElAire = 0;
        }
        else
        {
            animator.SetBool("isGrounded", false);
            isGround = false;

            if (isJump && VelocidadGravedad.y < 0)
            {
                animator.SetBool("isFalling", true);

                //Para calcular distancia caída
                isFalling = true;
                TiempoEnElAire += (1 * Time.deltaTime);
            }
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            VelocidadGravedad.y = Mathf.Sqrt(HeightJump * -2f * gravedad);
            animator.SetBool("isJumping", true);
            isJump = true;
        }
        //Por si se cae solo así
        if (!isJump && !isGrounded)
        {

            animator.SetBool("isFalling", true);
            //Para calcular distancia caída
            isFalling = true;
            TiempoEnElAire += (1 * Time.deltaTime);
        }

        VelocidadGravedad.y += gravedad * Time.deltaTime;
        Controller.Move(VelocidadGravedad * Time.deltaTime);

    }

    void Ataque()
    {
        if (!enConversacion && Input.GetMouseButtonDown(0)) //if (animacionNpc != null && !animacionNpc.enConversacion && Input.GetMouseButtonDown(0)) "Si  está asignado, el jugador NO está en conversación con el NPC, y el botón izquierdo del ratón fue presionado, entonces ejecuta lo que sigue"
        {
            animator.SetTrigger("AttackT");
            tiempoUltimoUso = Time.time;
            
        }
        else
        {
            animator.SetBool("isMoving", true);
        }
    }

    public void ActivarPersonajeSinArma()
    {

        ArmaMosquete = false;//para que no reconozca la bala

        personajeSinArma.SetActive(true);
        personajeConLanza.SetActive(false);
        personajeConEspada.SetActive(false);
        personajeMosquete.SetActive(false);

        animator = personajeSinArma.GetComponentInChildren<Animator>();
        tiempoUltimoUso = Time.time;

        StatsPlayer.Instance.SetPlayerDamage(10f);
        
        EnPrimeraPersona = false;

        CamaraTP.SetActive(true);
        CamaraFP.SetActive(false);
    }
    void ActivarPersonajeLanza()
    {
        CamaraTP.SetActive(true);
        CamaraFP.SetActive(false);
        
        EnPrimeraPersona = false;

        personajeSinArma.SetActive(false);
        personajeConLanza.SetActive(true);
        personajeConEspada.SetActive(false);
        personajeMosquete.SetActive(false);

        ArmaMosquete = false; //Desactivara el mosquete y no lo dectara para sacar la bala
        animator = personajeConLanza.GetComponentInChildren<Animator>();
        tiempoUltimoUso = Time.time;

        StatsPlayer.Instance.SetPlayerDamage(15f);

    }
    void ActivarPersonajeEspada()
    {
        EnPrimeraPersona = false;

        CamaraTP.SetActive(true);
        CamaraFP.SetActive(false);

        personajeSinArma.SetActive(false);
        personajeConLanza.SetActive(false);
        personajeConEspada.SetActive(true);
        personajeMosquete.SetActive(false);

        animator = personajeConEspada.GetComponentInChildren<Animator>();
        tiempoUltimoUso = Time.time;

        StatsPlayer.Instance.SetPlayerDamage(20f);

    }

    void ActivarPersonajeMosquete()
    {
        CamaraFP.SetActive(true);
        CamaraTP.SetActive(false);
        EnPrimeraPersona = true;

        personajeSinArma.SetActive(false);
        personajeConLanza.SetActive(false);
        personajeConEspada.SetActive(false);
        personajeMosquete.SetActive(true);

        animator = personajeMosquete.GetComponentInChildren<Animator>();
        tiempoUltimoUso = Time.time;

        StatsPlayer.Instance.SetPlayerDamage(5f);
    }
    void DispararMosquete()
    {
        if (ArmaMosquete && Input.GetMouseButtonDown(0) && !enConversacion)
        {
            if (instanciaBala != null)
            {
                instanciaBala.dispara();
            }
        }
    }

    #region Activar/Desactivar ataques si está hablando
    public void ActivarHablarNPC()
    {
        enConversacion = true;
    }

    public void DesactivarHablarNPC()
    {
        enConversacion = false;
    }

    public void EnCutscene()
    {
        InCutscene = true;
    }

    public void SeAcaboCutscene()
    {
        InCutscene = false;

    }
    /*public void JuegoPausado(bool SePauso)
    {
        IsPaused = SePauso;
    }*/
    #endregion

}