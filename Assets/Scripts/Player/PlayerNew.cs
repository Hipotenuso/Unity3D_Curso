using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Diagnostics;
using Unity.VisualScripting;
using System.Collections.Generic;
using DG.Tweening.Core.Easing;

public class PlayerNew : MonoBehaviour, IDamageble
{
    public float speed = 3f;
    public float speedRun = 6f;
    public float currentSpeed;
    public float turnSpeed = 1f;
    public float gravity = -9.8f;
    public float jumpSpeed = 10f;
    float vSpeed;
    public CharacterController characterController;
    public Animator animator;
    PlayerNew playerN;
    public KeyCode keyJump = KeyCode.Space;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }
    
    [Header("Run Setup")]
    public KeyCode keyRun = KeyCode.LeftShift;
    [Header("Flash")]
    public List<FlashColor> flashColors;
    void Update()
    {
        PlayerNewMoviment();
    }

    public void PlayerNewMoviment()
    {
        if(Input.GetKey(keyRun))
        {
            currentSpeed = speedRun;
            animator.speed = speedRun;
        }
        else
        {
            currentSpeed = speed;
            animator.speed = 1f;
        }

        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

        var inputAxisVertical = Input.GetAxis("Vertical");
        var speedVector = transform.forward * inputAxisVertical * currentSpeed;

        if (characterController.isGrounded)
        {
            vSpeed = 0;
            if(Input.GetKeyDown(keyJump))
            {
                vSpeed = jumpSpeed;
            }
        }

        vSpeed -= gravity * Time.deltaTime;
        speedVector.y = vSpeed;

        

        characterController.Move(speedVector * Time.deltaTime);

        animator.SetBool("Run", inputAxisVertical != 0);
    }
    #region LIFE
    public void Damage(float damage)
    {
        flashColors.ForEach(i => i.Flash());
    }

    public void Damage(float damage, Vector3 dir)
    {
        Damage(damage);
    }
    #endregion
}
