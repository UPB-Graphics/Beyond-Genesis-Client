﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform target;


    void Update()
    {
        transform.position = target.position - new Vector3(2f, 0f, 2f);
    }
}