using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    private Animator _animator;
    [SerializeField]
    private PlayerController _playerController;
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
        if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
        {
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }

        _animator.SetBool("isJumping", _playerMovement.isJumping);

        if (!_playerMovement.isJumping)
        {
            if (Input.GetMouseButton(0))
            {
                _animator.SetBool("isShooting", true);
            }
            else
            {
                _animator.SetBool("isShooting", false);
            }

            if (Input.GetMouseButton(1) && _playerController.meleeAttack.canDamage == true)
            {
                _animator.SetBool("isSlashing", true);
                
            }
            else
            {
                _animator.SetBool("isSlashing", false);
            }
        }







    }
}
