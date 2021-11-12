using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    [SerializeField] private PortalTeleporter _firstPortal;
    [SerializeField] private PortalTeleporter _secondPortal;

    [SerializeField] private float _maxDistance;
    [SerializeField] private LayerMask _hitableLayer;
    [SerializeField] private float _groundOffset;

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, _maxDistance, _hitableLayer))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _firstPortal.transform.rotation = Quaternion.LookRotation(hit.normal);
                    _firstPortal.transform.position = hit.point + _firstPortal.transform.forward * _groundOffset;
                }
                
                if (Input.GetMouseButtonDown(1))
                {
                    _secondPortal.transform.rotation = Quaternion.LookRotation(hit.normal);
                    _secondPortal.transform.position = hit.point + _secondPortal.transform.forward * _groundOffset;
                }
            }
        }
    }
}
