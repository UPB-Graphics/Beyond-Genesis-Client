using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Acest script ofera un controller pentru camera.
 * Are mai multe functionalitati printre care:
 *      Posibilitatea de inversa directia pe OY
 *      Posibilitatea de a schimba umarul cand este in third-person
 *      Apasarea tastelor CTRL+C face toggle intre first-person si third-person
 *      Rotita face zoom
 *      
 * @author Hariga George-Codrin (VladTeapa github)
 * 
 * @param Target
 *      Acest parametru reprezinta tinta pe care camera o va urmari
 * @param CameraOffset
 *      Acest parametru reprezinta offset-ul in modul third-person
 * @param CameraOffsetFirstPerson
 *      Acest parametru reprezinta offset-ul in modul first-person,
 *      Se poate pune zero daca targetul este capul player-ului
 * @param CameraOffsetZLimits
 *      Acest parametru controleaza cat de mult se poate da zoom
 * @param SensitivityZoom
 *      Acest parametru controleaza sensitivitatea zoom-ului
 * @param FollowSpeed
 *      Acest parametru controleaza viteza de urmarire
 * @param FollowSpeedKeepClose
 *      Acest parametru influenteaza cat de repede va urmari
 *      personajul in functie de distanta
 * @param MaximumAngle
 *      Unghiul maxim pe OY
 * @param MinimumAngle
 *      Unghiul minim pe OY
 * @param Inverted
 *      Acest parametru controleaza daca miscarea pe OY
 *      a mouse-ului este inversata
 * @param IsFirstPerson
 *      Acest parametru controleaza daca este perspectiva first-person
 *      sau perspectiva third-person
 */
public class CameraController : MonoBehaviour
{
    /**
     * @author Hariga George-Codrin (VladTeapa github)
     * Acest enum este folosit in loc de bool
     * pentru a se vedea mai usor in inspector
     * si pentru a se calcula mai usor rotatia pe OY
     */
    public enum CAMERA_INVERTED{
        INVERTED = -1,
        NOT_INVERTED = 1
    };
    public Transform Target;
    public Vector3 CameraOffset;
    public Vector3 CameraOffsetFirstPerson;
    public Vector2 CameraOffsetZLimits;
    public float SensitivityZoom;
    public float FollowSpeed;
    public float FollowSpeedKeepClose;
    public float MaximumAngle = 60f;
    public float MiniumAngle = -60f;

    public CAMERA_INVERTED Inverted;
    public bool IsFirstPerson = false;

    /**
     * Parametri privati folositi in functii
     */
    private Vector3 realCameraOffset, realCameraOffsetFirstPerson, newCameraPosition;
    private float yaw = 0;
    private float pitch = 0;


    /**
     * Aceasta functie verifica inputul de la
     * tastatura si schimba variabilele corespunzator
     * 
     * @author Hariga George-Codrin (VladTeapa github)
     */
    public void CameraControlls()
    {

        /**
         * Acest if face toggle intre first-person si third-person
         */
        if (Input.GetKey(KeyCode.LeftControl)) 
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                IsFirstPerson = !IsFirstPerson;

                newCameraPosition = Target.position + transform.TransformDirection(realCameraOffset);

                transform.position = newCameraPosition;
                transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
            }
        }
        
        /**
         * Acest if modifica umarul la care este camera in third-person
         */
        if (Input.GetKeyDown(KeyCode.H))
        {
            realCameraOffset.x = -realCameraOffset.x;
        }

        /**
         * Acest cod are rolul de a face toggle intre inputul inverted pe OY
         */
        if (Input.GetKeyDown(KeyCode.I))
        {
            Inverted = (CAMERA_INVERTED)((int)Inverted * -1);
        }
        
        /**
         * Acest cod de mai jos se ocupa de partea de zoom
         */
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll < 0)
        {
            realCameraOffset.z -= SensitivityZoom;
        }
        if (scroll > 0)
        {
            realCameraOffset.z += SensitivityZoom;
        }
        CheckCameraBoundries();
    }


    /**
     * Functia start initializeaza offset-ul care
     * este de fapt folosit in final la calcule
     * 
     * @author Hariga George-Codrin (VladTeapa github)
     */
    private void Start()
    {
        realCameraOffset = new Vector3();
        realCameraOffset = CameraOffset;
        realCameraOffsetFirstPerson = new Vector3();
    }

    /**
     * Functia LateUpdate are rolul de a actualiza
     * pozitia si rotatia camerei; Folosim LateUpdate, deoarece
     * in general, noua pozitie a player-ului este calculata in Update
     * 
     * @author Hariga George-Codrin (VladTeapa github)
     */
    private void LateUpdate() 
    {

        /**
         * Se verifica prima oara tastele apasate
         */
        CameraControlls();

        /** 
         * Se ia noua rotatie de la mouse
         */
        pitch -= Input.GetAxis("Mouse Y") * (float)Inverted; 
        yaw += Input.GetAxis("Mouse X");

        /**
         * Se limiteaza unghiul pe OY
         */
        pitch = Mathf.Clamp(pitch, MiniumAngle, MaximumAngle);

        /**
         * Se seteaza rotatie si se calculeaza 
         * pozitia noua si directia de miscare
         */
        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
        newCameraPosition = Target.position + transform.TransformDirection(realCameraOffset);
        Vector3 cameraMoveDir = newCameraPosition - transform.position;

        /** 
         * In functie daca este first person sau third person
         * se modifica pozitia camerei
         */
        if (cameraMoveDir.magnitude > 10e-3f && !IsFirstPerson)
        {
            transform.position += cameraMoveDir.normalized *
                                Mathf.Min(cameraMoveDir.magnitude, Time.deltaTime * FollowSpeed *
                                (1 + cameraMoveDir.magnitude * FollowSpeedKeepClose));
        }
        else if (IsFirstPerson)
        {
            realCameraOffsetFirstPerson = CameraOffsetFirstPerson;
            transform.position = Target.transform.position + transform.TransformDirection(realCameraOffsetFirstPerson);
        }
    }

    /**
     * Functia CheckCameraBoundries verifica daca zoom-ul depaseste
     * parametri setati si ajusteaza in caz contrar
     * 
     * @author Hariga George-Codrin (VladTeapa github)
     */
    private void CheckCameraBoundries()
    {
        if (realCameraOffset.z > CameraOffsetZLimits.y)
        {
            realCameraOffset.z = CameraOffsetZLimits.y;
        }
        if (realCameraOffset.z < CameraOffsetZLimits.x)
        {
            realCameraOffset.z = CameraOffsetZLimits.x;
        }
    }
}
