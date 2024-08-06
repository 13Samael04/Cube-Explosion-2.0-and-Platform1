using System;
using UnityEngine;

using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Renderer _renderer;
    private int _minTimeToDestroy = 1;
    private int _maxTimeToDestroy = 6;
    private Color _startColor = Color.green;
    private bool _isHit = false;

    public Rigidbody Rigidbody { get; private set; }
    public Renderer Renderer { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Renderer = GetComponent<Renderer>();
        Renderer.material.color = _startColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Platform>(out Platform platform) && _isHit == false)
        {
            _isHit = true;
            ChangeColor();
            Delete();
        }
    }

    private void OnEnable()
    {
        _isHit = false;
        Renderer.material.color = _startColor;
    }

    private void ChangeColor()
    {
        Renderer.material.color = Color.red;
    }

    private void Delete()
    {
        int timeToDestroy = Random.Range(_minTimeToDestroy, _maxTimeToDestroy);
        Destroy(gameObject, timeToDestroy);
    }
}
