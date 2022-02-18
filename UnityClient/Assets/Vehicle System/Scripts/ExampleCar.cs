using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleCar : VehicleBase
{

    public float carSpeed = 10f;

    // Start is called before the first frame update
    public override VehicleControlModel ManageInput()
    {
        if (Input.GetKeyDown(KeyCode.E) && insideTheVehicle)
            GetOutVehicle();

         HandleCamera();

        float currentPlayerDistance = (player.transform.position - transform.position).magnitude;

        if (Input.GetKeyDown(KeyCode.E) && currentPlayerDistance < interactionRange && !insideTheVehicle)
            GetInsideVechicle();

        var x = Input.GetAxisRaw("Horizontal");
        var z = Input.GetAxisRaw("Vertical");

        VehicleControlModel controlOutput = new VehicleControlModel { Direction = new Vector3(x, 0, z).normalized }; 

        return controlOutput;
    }

    public override void ControlVehicle(VehicleControlModel controlInput)
    {
        transform.position += controlInput.Direction * carSpeed * Time.deltaTime;
    }

    public override void HandleCamera()
    {
        if (insideTheVehicle)
        {
            mainCamera.transform.position = transform.position + new Vector3(0, 9, -5);
            mainCamera.transform.LookAt(transform.position);
        }
    }
}
