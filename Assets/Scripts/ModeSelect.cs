using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelect : MonoBehaviour
{
    public void OnClick()
    {
        if(gameObject.tag == "solo")
        {
            SceneManager.LoadScene("Solomode");
        }
    }

}
