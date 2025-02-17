using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Diagnostics;
using Unity.VisualScripting;

public class PlayerNew : MonoBehaviour
{
    public float speed = 3f;
    public float speedRun = 6f;
    public float currentSpeed;
    public float turnSpeed = 1f;
    public float gravity = -9.8f;
    public float jumpSpeed = 10f;
    float vSpeed;
    public CharacterController characterController;
    Animator animator;
    PlayerNew playerN;
    States currentState;
    public KeyCode keyJump = KeyCode.Space;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        currentState = new Idle(gameObject, this);
    }
    
    [Header("Run Setup")]
    public KeyCode keyRun = KeyCode.LeftShift;

    void Update()
    {
        currentState = currentState.Process();
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
}
