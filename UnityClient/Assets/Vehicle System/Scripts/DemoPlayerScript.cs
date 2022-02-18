using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoPlayerScript : MonoBehaviour
{
    public float movementSpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var z = Input.GetAxisRaw("Vertical");


        if (Input.GetKeyDown(KeyCode.P))
            Debug.Log("player PING"); //this is for debug purposes

        Vector3 move = new Vector3(x, 0, z);



        transform.position += move.normalized * movementSpeed * Time.deltaTime;
    }
}
