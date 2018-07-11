using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float _speed = 10;
    [SerializeField]
    bool _isAttacking = false;
    Vector3 direction;
    public Rigidbody myRigidBody;
    [SerializeField]
    private NavMeshAgent _meshAgent;
    public AnimationCurve curve;
    public Transform camera;
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

    public float Speed
    {
        get
        {
            return _speed;
        }

        set
        {
            _speed = value;
            SetAgentSpeed();
        }
    }

    public bool IsAttacking
    {
        get
        {
            return _isAttacking;
        }

        set
        {
            _isAttacking = value;
        }
    }

    void SetAgentSpeed()
    {
        _meshAgent.speed = _speed + 2;

    }

    // Use this for initialization
    void Start()
    {
        if (curve.length == 0)
        {
            Debug.LogError("No Curve given to PlayerMovement!");
        }
        SetAgentSpeed();

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

            if (Input.GetAxisRaw("Jump") > 0 && !_isAttacking)
            {
                Jump = 1;
            }

        }

        //Translate position---------------------------------------------------




        Vector3 camForward = camera.transform.forward;
        camForward.y = 0;
        Vector3 camRight = camera.transform.right;
        Vector3 targetDirection = (camRight * Horz) + (camForward * Vert);


        if (isJumping)
        {
            Debug.Log("Trying to jump");

            float jumpY = curve.Evaluate(jumpTime) * jumpHeight;

            _meshAgent.baseOffset = (jumpY + 0.5f);


            jumpTime += Time.deltaTime / jumpDuration;
            if (jumpTime >= 1)
            {
                isJumping = false;


            }
        }
        else
        {

            _meshAgent.baseOffset = 0.5f;
            jumpCoolDown += Time.deltaTime;
        }

        if (_isAttacking)
        {
            if (_meshAgent.enabled)
            {
                _meshAgent.enabled = false;
            }



            Vert = 1;
            Horz = 0;

            camForward = camera.transform.forward;
            camForward.y = 0;
            camRight = camera.transform.right;
            targetDirection = (camRight * Horz) + (camForward * Vert);

            transform.LookAt(new Vector3((targetDirection + transform.position).x, transform.position.y, (targetDirection + transform.position).z),Vector3.up);

        }
        else
        {
            if (!_meshAgent.enabled)
            {
                _meshAgent.enabled = true;
            }

        }
        _meshAgent.destination = targetDirection + transform.position;
        
    }





    public float jumpTime;
    public float jumpDuration = 1;
    float startY;

    float jumpCoolDown;


    RaycastHit detectGround;
    void OnJumpUpdate()
    {
        if (isJumping == false)
        {
            if (_meshAgent.baseOffset == 0.5f)
            {
                if (Physics.Raycast(myRigidBody.centerOfMass, new Vector3(0, -1, 0), out detectGround, 1f, LayerMask.GetMask("Ground")))
                {
                    Debug.Log(detectGround.collider.tag);
                    if (detectGround.collider.tag == "Ground")
                    {
                        isJumping = true;
                        jumpTime = 0;
                    }
                }
            }
        }
    }

    void OnHorzUpdate()
    {
        direction.z = Vert;
    }

    void OnVertUpdate()
    {
        direction.x = Horz;
    }


}
