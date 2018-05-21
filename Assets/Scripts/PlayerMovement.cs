using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float _vert;
    float _horz;

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

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetAxisRaw("Vertical") != 0)
            {
                Vert = Input.GetAxisRaw("Vertical");
            }

            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                Horz = Input.GetAxisRaw("Horizontal");
            }
        }
    }


    void OnHorzUpdate()
    {

    }
    void OnVertUpdate()
    {

    }
}
