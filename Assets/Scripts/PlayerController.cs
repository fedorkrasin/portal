using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var vertical = _speed * Input.GetAxis("Vertical");
        var horizontal = _speed * Input.GetAxis("Horizontal");
        
        transform.position += Vector3.back * vertical * Time.deltaTime;
        transform.position += Vector3.left * horizontal * Time.deltaTime;
    }
}
