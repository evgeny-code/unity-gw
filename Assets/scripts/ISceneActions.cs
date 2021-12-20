using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ISceneActions : MonoBehaviour
{
    public GameObject cube;

    public void MenuButtonClick()
    {
        SceneManager.LoadScene("menu_scene", LoadSceneMode.Single);
    }
    
    public void LoadImageButtonClick()
    {
       Debug.Log("Load img");
       StartCoroutine(loadImage());
    }

    private IEnumerator<UnityWebRequestAsyncOperation> loadImage()
    {
        UnityWebRequest request = UnityWebRequest.Get("http://192.168.1.37:8080/images/default/random");
        yield return request.SendWebRequest();
        
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
            StartCoroutine(GetTexture(request.downloadHandler.text));
        }
    }
    
    private IEnumerator GetTexture(string url) {
        Debug.Log(url);
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            Texture2D myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            Debug.Log(myTexture);
            cube.GetComponent<Renderer>().material.mainTexture = myTexture;
        }
    }
}
