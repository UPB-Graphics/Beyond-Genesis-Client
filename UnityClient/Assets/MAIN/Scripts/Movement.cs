
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{

	public float InputX;
	public float InputZ;
	public Vector3 desiredMoveDirection;
	public bool blockRotationPlayer;
	public float desiredRotationSpeed = 0.1f;
	public Animator anim;
	public float Speed;
	public float allowPlayerRotation = 0.1f;
	public Camera cam;
	public CharacterController controller;
	public bool isGrounded;

	[Header("Animation Smoothing")]
	[Range(0, 1f)]
	public float HorizontalAnimSmoothTime = 0.2f;
	[Range(0, 1f)]
	public float VerticalAnimTime = 0.2f;
	[Range(0, 1f)]
	public float StartAnimTime = 0.3f;
	[Range(0, 1f)]
	public float StopAnimTime = 0.15f;


	private float verticalVel;
	private Vector3 moveVector;

	// Use this for initialization
	void Start()
	{
		cam = Camera.main;
	}

	// Update is called once per frame
	void Update()
	{
		LockAndUnlockCursor();
		InputMagnitude();
	}
	// Hide Cursor
	void LockAndUnlockCursor()
	{

		if (Input.GetKeyDown(KeyCode.Escape))
		{

			if (Cursor.lockState == CursorLockMode.Locked)
			{

				Cursor.lockState = CursorLockMode.None;


			}
			else
			{

				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;

			}

		}

	}

	void PlayerMoveAndRotation()
	{
		InputX = Input.GetAxis("Horizontal");
		InputZ = Input.GetAxis("Vertical");

		var camera = Camera.main;
		var forward = cam.transform.forward;
		var right = cam.transform.right;

		forward.y = 0f;
		right.y = 0f;

		forward.Normalize();
		right.Normalize();

		desiredMoveDirection = forward * InputZ + right * InputX;

		if (GetComponent<Animations>().aiming)
			return;

		if (blockRotationPlayer == false)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
			controller.Move(desiredMoveDirection * Time.deltaTime * 3);
		}
	}

	// Used in Animations class
	public void RotateToCamera(Transform t)
	{

		var camera = Camera.main;
		var forward = cam.transform.forward;
		var right = cam.transform.right;

		desiredMoveDirection = forward;

		t.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);

	}

	// Get mouse input values, set speed and apply changes to the player
	void InputMagnitude()
	{
		InputX = Input.GetAxis("Horizontal");
		InputZ = Input.GetAxis("Vertical");

		Speed = new Vector2(InputX, InputZ).sqrMagnitude;

		//Move player
		if (Speed > allowPlayerRotation)
		{
			PlayerMoveAndRotation();
		}
	}
}
