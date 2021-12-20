using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    public void StartButtonClick()
    {
        SceneManager.LoadScene("b_scene", LoadSceneMode.Single);
    }

    public void ImageButtonClick()
    {
        SceneManager.LoadScene("i_scene", LoadSceneMode.Single);
    }
    
    public void QuitButtonClick()
    {
        Application.Quit();
    }
}
