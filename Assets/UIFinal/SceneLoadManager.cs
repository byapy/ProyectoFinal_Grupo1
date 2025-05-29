using System.Collections;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private Slider barraCarga;
    [SerializeField] private GameObject loadPanel;
    public CanvasGroup canvaNegro, slider, texto;

    public void LoadScene(int sceneIndex)
    {
        loadPanel.SetActive (true);
        //lamaremos corrutina
        StartCoroutine (LoadAsync (sceneIndex));
        canvaNegro.LeanAlpha(1, 0.3f).setEase(LeanTweenType.easeOutQuad).setOnComplete(imagenesCarga); ;
        
    }
    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);//este loadSceneAsync no pausa lo que pasa detras

        while (!asyncOperation.isDone)
        {
            Debug.Log(asyncOperation.progress);
            barraCarga.value = asyncOperation.progress/ 0.9f;
            yield return null;
        }
    }
    void imagenesCarga()
    {
       slider.LeanAlpha(1, 0.1f);
       texto.LeanAlpha(1, 0.1f);
       
    }
    
}
