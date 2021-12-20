using System;
using UnityEngine;
using Random = System.Random;

public class RandomScaler : MonoBehaviour
{
    private Random _random = new Random((int) DateTime.Now.Ticks);
    private MovingAvg _ma = new MovingAvg(20);
    private MovingAvg _rotateMa = new MovingAvg(20);

    public float direction = 0;
    private AudioSource _audioSource;
    private float _audioVollume = 0.5f;

    public void PlusDirection()
    {
        direction += 0.01f;
    }
    
    public void MinusDirection()
    {
        direction -= 0.01f;
    }

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float change = (float) (_random.NextDouble() - 0.5 + direction);
        _ma.PUT(change);
        _rotateMa.PUT((float) (_random.NextDouble()-0.5));
        
        gameObject.transform.localScale = gameObject.transform.localScale * (1 + Time.deltaTime * _ma.GETAvg());
        _audioVollume = _audioVollume * (1 + Time.deltaTime * _ma.GETAvg());
        _audioSource.volume = _audioVollume;
        
        gameObject.transform.Rotate(Vector3.up, 100*Time.deltaTime * _rotateMa.GETAvg());
    }
}

public class MovingAvg
{
    private float[] _data;
    private int _currentIdx = 0;

    public MovingAvg(int size)
    {
        _data = new float[size];
    }

    public void PUT(float val)
    {
        _data[_currentIdx] = val;
        _currentIdx = (_currentIdx + 1) % _data.Length;
    }

    public float GETAvg()
    {
        float sum = 0;
        for (int i = 0; i < _data.Length; i++)
            sum += _data[i];

        return sum / _data.Length;
    }
}