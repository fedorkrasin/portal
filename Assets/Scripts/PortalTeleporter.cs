using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    [SerializeField] private PortalTeleporter _otherPortal;

    private void Teleport(Transform obj)
    {
        var localPosition = transform.worldToLocalMatrix.MultiplyPoint3x4(obj.position);
        localPosition = new Vector3(-localPosition.x, localPosition.y, -localPosition.z);
        obj.position = _otherPortal.transform.localToWorldMatrix.MultiplyPoint3x4(localPosition);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("trigger");
        
        var zPos = transform.worldToLocalMatrix.MultiplyPoint3x4(other.transform.position).z;

        if (zPos < 0)
        {
            Teleport(other.transform);
        }
    }
}
