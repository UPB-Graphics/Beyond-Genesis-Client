using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacingBillboard : MonoBehaviour
{
    private void Update()
    {
        Camera cam = Camera.main;

        if (cam != null)
        {
            transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward,
            cam.transform.rotation * Vector3.up);
        }
        else
        {
            Debug.LogError("Main camera is NULL!");
        }
    }
}
