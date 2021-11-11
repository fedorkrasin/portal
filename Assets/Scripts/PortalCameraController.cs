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
    }
}
