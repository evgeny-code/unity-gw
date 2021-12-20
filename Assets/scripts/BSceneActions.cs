using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BSceneActions : MonoBehaviour
{
    public void MenuButtonClick()
    {
        SceneManager.LoadScene("menu_scene", LoadSceneMode.Single);
    }
}
