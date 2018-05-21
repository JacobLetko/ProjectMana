using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [Header("Camera Variables")]
    public float mouseSensX = 3.5f;//Sensativity x
    public float mouseSensY = 3.5f;//sensativity Y
    Transform camT;
    float vertLookRotation;


    // Use this for initialization
    void Start()
    {
        camT = Camera.main.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Look rotation-----------------------------------------------------------------------------------------------------------------------------------

        //vertLookRotation += Input.GetAxis("Mouse Y") * mouseSensY;

        //vertLookRotation = Mathf.Clamp(vertLookRotation, -60, 60);

        //camT.localEulerAngles = Vector3.left * vertLookRotation;

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensX);//Do not multiply by time.deltatime as mouse input is frame independant
    }
}
