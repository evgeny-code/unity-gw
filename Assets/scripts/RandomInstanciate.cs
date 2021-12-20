using System;
using UnityEngine;
using Random = System.Random;

public class RandomInstanciate : MonoBehaviour
{
    private Random _random = new Random((int) DateTime.Now.Ticks);
    
    public GameObject prefab;
    public int count = 100;
    public int max = 100;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(prefab, 
                new Vector3(_random.Next(-max, max), _random.Next(-max, max), _random.Next(-max, max)), 
                Quaternion.LookRotation(new Vector3(_random.Next(), _random.Next(), _random.Next())));
        }
    }
}
