using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RetryGame : MonoBehaviour
{
    private string sceneName;
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    
    public void OnClick()
    {
        if(gameObject.tag == "retry")
        {
            SceneManager.LoadScene(sceneName);
        }

        if(gameObject.tag == "title")
        {
            SceneManager.LoadScene("Title");
        }

        if(gameObject.tag == "exit")
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;   
#else
        Application.Quit();                                
#endif
        }
    }
}
