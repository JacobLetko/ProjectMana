using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    Vector3 normalizedDirection;
    public Rigidbody rigidBody;
    public AnimationCurve curve;
    //float jumpOffset = 0;
    public float jumpHeight = 1;
    //public float jumpEvaluationScale = 1;

    public bool isJumping = false;

    float _vert;
    float _horz;
    float _jump;
    float Jump
    {
        get
        {
            return _jump;
        }
        set
        {
            _jump = value;
            OnJumpUpdate();
        }
    }

    float Vert
    {
        get
        {
            return _vert;
        }
        set
        {
            _vert = value;
            OnHorzUpdate();
        }
    }
    float Horz
    {
        get
        {
            return _horz;
        }
        set
        {
            _horz = value;
            OnVertUpdate();
        }
    }
    // Use this for initialization
    void Start()
    {
        if (curve.length == 0)
        {
            Debug.LogError("No Curve given to PlayerMovement!");
        }
    }

    // Update is called once per frame
    void Update()
    {


        //Reset direction on frame start----------------------------------------
        Vert = 0;
        Horz = 0;



        //Recieve input--------------------------------------------------------
        if (Input.anyKey)
        {

            if (Input.GetAxisRaw("Vertical") != 0)
            {
                Vert = Input.GetAxisRaw("Vertical");
            }

            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                Horz = Input.GetAxisRaw("Horizontal");
            }

            if (Input.GetAxisRaw("Jump") > 0)
            {
                Jump = 1;
            }

        }

        //Translate position---------------------------------------------------
        if (isJumping)
        {
            Debug.Log("Trying to jump");
            float jumpY = curve.Evaluate(jumpTime) * jumpHeight;
            rigidBody.AddForce(new Vector3(0, jumpY, 0));

            //transform.position = new Vector3(transform.position.x, startY + jumpY, transform.position.z);
            jumpTime += Time.deltaTime / jumpDuration;
            if (jumpTime >= 1)
            {
                isJumping = false;

                //transform.position =new Vector3(transform.position.x, startY, transform.position.z);
            }
        }
        else
        {
            jumpCoolDown += Time.deltaTime;
        }

        transform.Translate(normalizedDirection.normalized * speed * Time.deltaTime);
       

    }

    float jumpTime;
    public float jumpDuration = 1;
    float startY;
    RaycastHit detectGround;
    bool grounded = true;
    float jumpCoolDown;



    void OnJumpUpdate()
    {
        if (isJumping == false)
        {
            if (Physics.Raycast(transform.position, new Vector3(0, -1, 0), out detectGround, 0.5f))
            {
                if (detectGround.collider.tag == "Ground")
                {
                    isJumping = true;
                    jumpTime = 0;
                }
            }

        }

        //startY = transform.position.y;
    }

    void OnHorzUpdate()
    {
        normalizedDirection.z = Vert;
    }

    void OnVertUpdate()
    {
        normalizedDirection.x = Horz;
    }

}
