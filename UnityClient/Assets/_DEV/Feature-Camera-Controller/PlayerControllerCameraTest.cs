using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerCameraTest : MonoBehaviour
{

    public float Speed;
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= Vector3.forward * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= Vector3.right * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * Speed;
        }
    }
}
