using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePet : MonoBehaviour
{
    float TimeDelay = 1.0f;
    public Transform ObjectToFollow;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //Implement this such that it return the number of seconds to wait before next action is chosen
    //The input is a random value between 0 and 1.0f , use this to determine the action
    //Actions can be whatever you want, typically you will use them to drive an animation controller
    public abstract float DoPetAction(float action);
    //Implement this such that the pet follows ObjectToFollow in the desired manner.
    public abstract void DoFollow(float fixedDT);
    private void FixedUpdate()
    {
        DoFollow(Time.fixedDeltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        TimeDelay -= Time.deltaTime;
        if(TimeDelay <= 0)
        {
            TimeDelay = DoPetAction(Random.Range(0.0f, 1.0f));
        }
    }
}
