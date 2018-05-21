using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{



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

    public LayerMask mask;

    RaycastHit detectGround;












    // Use this for initialization
    void Start()
    {
        timer = jumpCoolDown;

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

        metersPerSec = myRig.velocity.magnitude;
        

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






            if (metersPerSec < HardSpeedLimmit)
            {
                if (metersPerSec <= 0.001)
                {
                    normalizedMovement = new Vector3(horz, 0, vert);
                    //myRig.AddRelativeForce((normalizedMovement.normalized * speed/2 * throttle) * Time.deltaTime, ForceMode.Impulse);
                    myRig.velocity = (transform.TransformVector(normalizedMovement.normalized) * speed / 2 * throttle) * Time.deltaTime;

                }
                else
                {

                    normalizedMovement = new Vector3(horz, 0, vert);



                    //myRig.AddRelativeForce((normalizedMovement.normalized * speed * throttle) * Time.deltaTime);
                    myRig.velocity = (transform.TransformVector(normalizedMovement.normalized) * speed * throttle) * Time.deltaTime;
                }

            }

        }
        else if (grounded && detectGround.transform.tag == "Ground")
        {
            if (myRig.velocity.magnitude != 0)
            {
                myRig.drag = stoppingPower;
            }

        }


        if (Input.GetAxis("Jump") != 0 && grounded == true)
        {
            //if(Physics.Raycast(transform.position,Vector3.up * -1 ,mask))// Shea Tips
            //   {


            //}


            if (canJump)
            {

                myRig.AddRelativeForce(((new Vector3(0, 1, 0) * jumpStrength) * throttle) * Time.deltaTime, ForceMode.Impulse);


                timer = 0;
            }


        }

    }
}