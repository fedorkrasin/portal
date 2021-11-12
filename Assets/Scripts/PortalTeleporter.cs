using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    [SerializeField] private PortalTeleporter _otherPortal;

    private void Teleport(Transform obj)
    {
        Move(obj);
        Rotate(obj);
    }

    private void OnTriggerStay(Collider other)
    {
        var zPos = transform.worldToLocalMatrix.MultiplyPoint3x4(other.transform.position).z;

        if (zPos < 0)
        {
            Teleport(other.transform);
        }
    }
    
    private void Move(Transform obj)
    {
        var localPosition = transform.worldToLocalMatrix.MultiplyPoint3x4(obj.position);
        localPosition = new Vector3(-localPosition.x, localPosition.y, -localPosition.z);
        obj.position = _otherPortal.transform.localToWorldMatrix.MultiplyPoint3x4(localPosition);
    }

    private void Rotate(Transform obj)
    {
        var difference = _otherPortal.transform.rotation *
                         Quaternion.Inverse(transform.rotation * Quaternion.Euler(0, 180, 0));
        
        obj.rotation = difference * obj.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.layer = 9;
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.layer = 8;
    }
}
