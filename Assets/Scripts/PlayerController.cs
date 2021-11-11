using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private Vector2 _rotation;
    
    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        var vertical = _speed * Input.GetAxis("Vertical");
        var horizontal = _speed * Input.GetAxis("Horizontal");

        var destinationVector = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
        transform.position += destinationVector * vertical * Time.deltaTime;
        transform.position += Vector3.left * horizontal * Time.deltaTime;
    }

    private void Rotate()
    {
        _rotation.x += Input.GetAxis("Mouse X") * _rotationSpeed;
        _rotation.y += Input.GetAxis("Mouse Y") * _rotationSpeed;
        transform.localRotation = Quaternion.Euler(-_rotation.y, _rotation.x, 0);
    }
}
