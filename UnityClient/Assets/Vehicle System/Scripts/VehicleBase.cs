using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleBase : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject player;
    public float interactionRange = 2f;
    public float existRightDistance = 5f;
    public float exitUpDistance = 2f;
    public Camera mainCamera;

    protected bool insideTheVehicle;

    // Update is called once per frame
    void Update()
    {
        VehicleControlModel controlInput = ManageInput();
        if(insideTheVehicle)
            ControlVehicle(controlInput);
    }

    public virtual VehicleControlModel ManageInput() { return null; }

    public virtual void ControlVehicle(VehicleControlModel controlInput) { }

    public virtual void HandleCamera() { } // override this function if you want different behavior for the camera

    public void GetInsideVechicle()
    {
        insideTheVehicle = true;
        player.SetActive(false);
    }

    public void GetOutVehicle()
    {
        insideTheVehicle = false;
        player.SetActive(true);
        player.transform.position = transform.position + transform.right * existRightDistance + transform.up * exitUpDistance;
    }
}
