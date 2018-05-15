using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Camera Variables")]
    public float mouseSensX = 3.5f;//Sensativity x
    public float mouseSensY = 3.5f;//sensativity Y
    Transform camT;
    float vertLookRotation;

    [Header("Movement")]
    public float speed;
    public float jumpStrength;
    public float throttle;//adjustable speed limmit. values ranges from 0 to 1.
    public float HardSpeedLimmit = 30;//in meters per second
    public float metersPerSec;
    public float jumpCoolDown;
    public float sprintSpeed;
    public float stoppingPower = 500;//What drag is set too when no input is detected. 500
    Vector3 normalizedMovement;
    float vert;// = Input.GetAxis("Vertical");
    float horz;// = Input.GetAxis("Horizontal");
    float myJump;
    float drag;
    bool canJump;
    Rigidbody myRig;

    float timer;
    float airTime;

    public bool grounded;


    RaycastHit detectGround;












    // Use this for initialization
    void Start()
    {
        timer = jumpCoolDown;
        camT = Camera.main.transform;
        myRig = GetComponent<Rigidbody>();

        normalizedMovement = new Vector3(0, 0, 0);

        drag = myRig.drag;


    }

    // Update is called once per frame
    void Update()
    {

        vert = 0;
        horz = 0;
        myJump = 0;
        normalizedMovement = new Vector3(0, 0, 0);
        /*
         * Input.GetAxis("Vertical") > 0 // gets forward
         * Input.GetAxis("Vertical") < 0 // gets backward
         * Input.GetAxis("Horizontal") > 0 // gets right
         * Input.GetAxis("Horizontal") < 0 // gets left
         */


        //Look rotation-----------------------------------------------------------------------------------------------------------------------------------
        metersPerSec = myRig.velocity.magnitude;

      

        vertLookRotation += Input.GetAxis("Mouse Y") * mouseSensY;

        vertLookRotation = Mathf.Clamp(vertLookRotation, -60, 60);

        camT.localEulerAngles = Vector3.left * vertLookRotation;

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensX);//Do not multiply by time.deltatime as mouse input is frame independant

        //------------------------------------------------------------------------------------------------------------------------------------------------

        grounded = Physics.Raycast(transform.position, new Vector3(0, -1, 0), out detectGround, 0.5f);







        //Movement controls-------------------------------------------------------------------------------------------------------------------------------


        vert = Input.GetAxis("Vertical");
        horz = Input.GetAxis("Horizontal");

        //Vector3 input = new Vector3(vert, 0, horz);
        //AddForce normalized
        

        if (grounded == true)
        {
            if (airTime > 0)
            {
                canJump = false;
            }

            if (canJump == false)
            {
                timer += Time.deltaTime;
                if (timer >= jumpCoolDown)
                {
                    canJump = true;
                    airTime = 0;
                    timer = 0;
                }
            }

            if (canJump == true)
            {
                myJump = Input.GetAxis("Jump");
            }

        }
        else
        {
            airTime += Time.deltaTime;
        }




        
        //------------------------------------------------------------------------------------------------------------------------------------------------



        //if (Input.GetKey(KeyCode.C))
        //{
        //Crouch
        //
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 || Input.GetAxis("Jump") != 0)
        {
            myRig.drag = drag;

            if (Input.GetAxis("Jump") != 0 && grounded == true)
            {

                if (canJump)
                {
                    myRig.AddRelativeForce(((new Vector3(0, 1, 0) * jumpStrength) * throttle) * Time.deltaTime, ForceMode.Impulse);
                    timer = 0;
                }


            }





            if (metersPerSec < HardSpeedLimmit)
            {
                if (metersPerSec <= 0.001)
                {
                    normalizedMovement = new Vector3(horz, 0, vert);
                    myRig.AddRelativeForce((normalizedMovement.normalized * speed/2 * throttle) * Time.deltaTime, ForceMode.Impulse);
                }
                else
                {

                    normalizedMovement = new Vector3(horz, 0, vert);



                    myRig.AddRelativeForce((normalizedMovement.normalized * speed * throttle) * Time.deltaTime);
                }

            }

        }
        else if(grounded && detectGround.transform.tag == "Ground")
        {
            if (myRig.velocity.magnitude != 0)
            {
                myRig.drag = stoppingPower;
            }
            
        }
    }
}