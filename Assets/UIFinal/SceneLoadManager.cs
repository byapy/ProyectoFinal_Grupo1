using System.Collections;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private Slider barraCarga;
    [SerializeField] private GameObject loadPanel;

    public void LoadScene(int sceneIndex)
    {
        loadPanel.SetActive (true);
        //lamaremos corrutina
        StartCoroutine (LoadAsync (sceneIndex)); 
        
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
   
    
}
