using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _airCapacity;
    [SerializeField] private float _boosterSpeed;

    private Vector3 _startDirection;
    
    public float torque;

    private float turn = 0;

    void Start()
    {
        _startDirection = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100));
        _rigidbody.AddTorque(_startDirection * (torque * -1));
        _rigidbody.AddForce(_startDirection * _boosterSpeed);
    }

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        turn = Input.GetAxis("Horizontal");
    }
    
    void FixedUpdate()
    {
        if (turn != 0)
        {
            _rigidbody.AddTorque(_startDirection * (torque * turn));
        }
    }

    private void AddBoost()
    {
        float turn = Input.GetAxis("Horizontal");
        _rigidbody.AddTorque(_startDirection * (torque * turn));
    }
}
