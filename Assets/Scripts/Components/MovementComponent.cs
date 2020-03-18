using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementComponent : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField]
    private float _speed = 2f;
    [SerializeField]
    private bool _isRelativeToCamera = false;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        if(_isRelativeToCamera)
        {
            direction = Camera.main.transform.TransformDirection(direction);
        }
        Vector3 velocity = direction * _speed;
        velocity.y = _rigidbody.velocity.y;

        _rigidbody.velocity = velocity;
    }
}
