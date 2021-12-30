using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace desert
{
    public class WorkCubeLoader: MonoBehaviour
    {
        public Vector3 startPoint = new Vector3(-66, 27, 72);
        public GameObject prefab;

        public List<string> images = new List<string>()
        {
            "https://github.com/evgeny-code/stunning-potato/raw/master/images/s1.jpeg",
            "https://github.com/evgeny-code/stunning-potato/raw/master/images/s2.jpeg"
        };

        void Start()
        {
            Load();
        }


        public void Load()
        {
            StartCoroutine(LoadImagesAndInstantiate());
        }

        private IEnumerator LoadImagesAndInstantiate()
        {
            Vector3 position = new Vector3(startPoint.x, startPoint.y, startPoint.z);
            foreach (string imageUrl in images)
            {
                UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageUrl);
                yield return request.SendWebRequest();
                
                Debug.Log(request.result);

                if (request.result == UnityWebRequest.Result.Success)
                {
                    Texture2D texture2D = ((DownloadHandlerTexture)request.downloadHandler).texture;
                    GameObject instance = Instantiate(prefab, position, Quaternion.identity);
                    
                    Debug.Log(instance);

                    position.z += 20;
                }
            }
        }
    }
}