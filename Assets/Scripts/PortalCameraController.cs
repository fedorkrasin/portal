using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCameraController : MonoBehaviour
{
    [SerializeField] private PortalCameraController _otherPortal;
    [SerializeField] private Camera _portalView;
    [SerializeField] private MeshRenderer _mesh;

    private void Start()
    {
        CreatePortalTexture();
    }

    private void Update()
    {
        SetPortalView();
    }

    private void CreatePortalTexture()
    {
        _otherPortal._portalView.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        _mesh.sharedMaterial.mainTexture = _otherPortal._portalView.targetTexture;
    }

    private void SetPortalView()
    {
        var playerPosition = _otherPortal.transform.worldToLocalMatrix.MultiplyPoint3x4(Camera.main.transform.position);
        playerPosition = new Vector3(-playerPosition.x, playerPosition.y, -playerPosition.z);
        _portalView.transform.localPosition = playerPosition;

        var difference = transform.rotation *
                         Quaternion.Inverse(_otherPortal.transform.rotation * Quaternion.Euler(0, 180, 0));
        _portalView.transform.rotation = difference * Camera.main.transform.rotation;

        _portalView.nearClipPlane = playerPosition.magnitude;
    }
}
