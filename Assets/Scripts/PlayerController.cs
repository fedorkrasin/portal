using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _horizontalRotationSpeed;
    [SerializeField] private float _verticalRotationSpeed;
    
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
        transform.position += transform.right * horizontal * Time.deltaTime;
    }

    private void Rotate()
    {
        var deltaX = Input.GetAxis("Mouse X") * _verticalRotationSpeed;
        var deltaY = Input.GetAxis("Mouse Y") * _horizontalRotationSpeed;;
        transform.localEulerAngles += new Vector3(-deltaY, deltaX, 0);
    }
}
