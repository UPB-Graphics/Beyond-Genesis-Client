using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleControlModel 
{
    // Start is called before the first frame update
    public Vector3 Direction { get; set; } //normalized vector to point in the direction we want to move the vechicle
    public Quaternion Rotation { get; set; }
    public float Force { get; set; }
}
