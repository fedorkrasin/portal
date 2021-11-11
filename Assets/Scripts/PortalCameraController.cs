using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCameraController : MonoBehaviour
{
    [SerializeField] private PortalCameraController _otherPortal;
    [SerializeField] private Camera _portalView;

    private void Update()
    {
        SetPortalView();
    }

    private void SetPortalView()
    {
        var playerPosition = _otherPortal.transform.worldToLocalMatrix.MultiplyPoint3x4(Camera.main.transform.position);
        _portalView.transform.localPosition = -playerPosition;

        var difference = transform.rotation *
                         Quaternion.Inverse(_otherPortal.transform.rotation * Quaternion.Euler(0, 180, 0));
        _portalView.transform.rotation = difference * Camera.main.transform.rotation;
    }
}
