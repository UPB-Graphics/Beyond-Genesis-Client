using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 10.0f;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private PathFollower pathFollower;

    private void Start()
    {
        pathFollower = GetComponent<PathFollower>();
    }

    private void Update()
    {
        var pos = transform.position;
        var dir = pathFollower.GetDirection(pos);
        if (dir != Vector3.zero)
        {
            var nextPosition = pos + dir * speed;
            transform.position = Vector3.SmoothDamp(pos, nextPosition, ref velocity, smoothTime);
        }
    }
}
