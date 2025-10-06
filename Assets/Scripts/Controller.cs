using System;
using UnityEngine;

public class Controller : MonoBehaviour
{
    
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    private void Update()
    {
        float positionZ = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        float positionX = -Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        _rigidbody.linearVelocity = new Vector3(positionX, 0, positionZ).normalized;
    }
}
