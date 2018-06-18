using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;
    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }

        if (Input.GetMouseButton(0))
        {
            _animator.SetBool("isShooting", true);
        }
        else
        {
            _animator.SetBool("isShooting", false);
        }

 
        _animator.SetBool("isJumping", _playerMovement.isJumping);




    }
}
