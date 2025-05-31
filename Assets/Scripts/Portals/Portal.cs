using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal linkedPortal;
    public MeshRenderer screen;
    Camera playerCam;
    Camera portalCam;
    public Material viewMaterial;

    private void Awake()
    {
        playerCam = Camera.main;
        portalCam = GetComponentInChildren<Camera>();
        var m = transform.localToWorldMatrix * linkedPortal.transform.worldToLocalMatrix * playerCam.transform.localToWorldMatrix;
        //viewMaterial = screen.material;
    }


    private void Start()
    {
        if (linkedPortal.portalCam.targetTexture != null)
        {
            linkedPortal.portalCam.targetTexture.Release();
        }
        linkedPortal.portalCam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        viewMaterial.mainTexture = linkedPortal.portalCam.targetTexture;
    }

    void LateUpdate()
    {
        var m = transform.localToWorldMatrix * linkedPortal.transform.worldToLocalMatrix * playerCam.transform.localToWorldMatrix;
        portalCam.transform.SetPositionAndRotation(m.GetColumn(3), m.rotation);
    }
}
