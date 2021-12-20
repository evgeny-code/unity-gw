using System;
using UnityEngine;
using Random = System.Random;

public class RandomRotate : MonoBehaviour
{
    private static Random _random = new Random((int) DateTime.Now.Ticks);
    private static int RND_MAX = 10000;

    private Vector3 _rotationAxis;
    private int _velocity;
    
    
    private void Start()
    {
        _rotationAxis = new Vector3(_random.Next(-RND_MAX, RND_MAX), _random.Next(-RND_MAX, RND_MAX),
            _random.Next(-RND_MAX, RND_MAX));

        _velocity = _random.Next(100);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.zero, 
            _rotationAxis, 
            _velocity * Time.deltaTime);
    }
}
