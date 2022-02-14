using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;

[RequireComponent(typeof(Animator))]
public class Animations : MonoBehaviour
{

    private Animator animator;
    private Movement input;
    private Rigidbody weaponRb;
    private WeaponScript weaponScript;
    private float returnTime;

    private Vector3 origLocPos;
    private Vector3 origLocRot;
    private Vector3 pullPosition;

    [Header("Public References")]
    public Transform weapon;
    public Transform hand;
    public Transform spine;
    public Transform curvePoint;
    [Space]
    [Header("Parameters")]
    public float throwPower = 30;
    public float cameraZoomOffset = .3f;
    [Space]
    [Header("Bools")]
    public bool walking = true;
    public bool aiming = false;
    public bool hasWeapon = true;
    public bool pulling = false;
    [Space]
    [Header("Particles and Trails")]
    public ParticleSystem glowParticle;
    public ParticleSystem catchParticle;
    public ParticleSystem trailParticle;
    public TrailRenderer trailRenderer;
    [Space]
    [Header("UI")]
    public Image cross;

    [Space]
    //Cinemachine Shake
    public CinemachineImpulseSource impulseSource;

    void Start()
    {
        Cursor.visible = false;

        animator = GetComponent<Animator>();
        input = GetComponent<Movement>();
        weaponRb = weapon.GetComponent<Rigidbody>();
        weaponScript = weapon.GetComponent<WeaponScript>();
        origLocPos = weapon.localPosition;
        origLocRot = weapon.localEulerAngles;

    }

    void Update()
    {

        //If aiming rotate the player towards the camera foward, if not reset the camera rotation on the x axis
        if (aiming)
        {
            input.RotateToCamera(transform);
        }
        else
        {
            transform.eulerAngles = new Vector3(Mathf.LerpAngle(transform.eulerAngles.x, 0, .2f), transform.eulerAngles.y, transform.eulerAngles.z);
        }

        //Animation States
        animator.SetBool("pulling", pulling);
        walking = input.Speed > 0;
        animator.SetBool("walking", walking);

        // Aim and start particles
        if (Input.GetMouseButtonDown(1) && hasWeapon)
        {
            Aim(true, 0);
        }

        // Stop Aiming and stop particles
        if (Input.GetMouseButtonUp(1) && hasWeapon)
        {
            Aim(false, 0);
        }

        // Throw weapon if you have it
        if (hasWeapon)
        {

            if (aiming && Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("throw");
            }

        }
        else // Pull weapon if you don't have it
        {
            if (Input.GetMouseButtonDown(0))
            {
                WeaponStartPull();
            }
        }

        if (pulling)
        {
            if (returnTime < 1)
            {
                weapon.position = GetQuadraticCurvePoint(returnTime, pullPosition, curvePoint.position, hand.position);
                returnTime += Time.deltaTime * 1.5f;
            }
            else
            {
                WeaponCatch();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
    }

    void Aim(bool state, float delay)
    {

        if (walking)
            return;

        aiming = state;

        animator.SetBool("aiming", aiming);

        //Particle
        if (state)
        {
            glowParticle.Play();
        }
        else
        {
            glowParticle.Stop();
        }

    }

    public void WeaponThrow()
    {
        Aim(false, 1f);

        hasWeapon = false;
        weaponScript.activated = true;
        weaponRb.isKinematic = false;
        weaponRb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        weapon.parent = null;
        weapon.eulerAngles = new Vector3(0, -90 + transform.eulerAngles.y, 0);
        weapon.transform.position += transform.right / 5;
        weaponRb.AddForce(Camera.main.transform.forward * throwPower + transform.up * 2, ForceMode.Impulse);

        //Trail
        trailRenderer.emitting = true;
        trailParticle.Play();
    }

    public void WeaponStartPull()
    {
        pullPosition = weapon.position;
        weaponRb.Sleep();
        weaponRb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        weaponRb.isKinematic = true;
        weaponScript.activated = true;
        pulling = true;
    }

    public void WeaponCatch()
    {
        returnTime = 0;
        pulling = false;
        weapon.parent = hand;
        weaponScript.activated = false;
        weapon.localEulerAngles = origLocRot;
        weapon.localPosition = origLocPos;
        hasWeapon = true;

        //Particle and trail
        catchParticle.Play();
        trailRenderer.emitting = false;
        trailParticle.Stop();

        //Shake
        impulseSource.GenerateImpulse(Vector3.right);

    }

    // Calculate curve path on return
    public Vector3 GetQuadraticCurvePoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        return (uu * p0) + (2 * u * t * p1) + (tt * p2);
    }
}
