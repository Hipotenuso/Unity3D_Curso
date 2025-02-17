using NUnit.Framework.Internal;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Player : MonoBehaviour
{
    public float speed = 3f;
    public float speedRun = 6f;
    public int jumpForce;
    public float jumpDuration;
    float currentSpeed;
    private bool jumping;
    States currentState;
    public Rigidbody myRigidbody;
    Animator animator;
    Player player;
    void Start()
    {
        jumping = false;
        myRigidbody = GetComponent<Rigidbody>();
        currentState = new Idle(gameObject, this);
    }

    void Update()
    {
        currentState = currentState.Process();
    }

    public void PlayerMoviment()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = speedRun;
        }
        else
        {
            currentSpeed = speed;
        }
        if(Input.GetKey(KeyCode.W))
        {
            myRigidbody.linearVelocity = new Vector3(currentSpeed, 0, 0);
        }
        if(Input.GetKey(KeyCode.A))
        {
            myRigidbody.linearVelocity = new Vector3(0, 0, currentSpeed);
        }
        if(Input.GetKey(KeyCode.S))
        {
            myRigidbody.linearVelocity = new Vector3(-currentSpeed, 0, 0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            myRigidbody.linearVelocity = new Vector3(0, 0, -currentSpeed);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(jumping != true)
            {
                jumping = true;
                myRigidbody.linearVelocity = Vector3.up * jumpForce;
                myRigidbody.transform.DOScale(new Vector3(.7f, 1.3f, .7f), jumpDuration).SetLoops(2, LoopType.Yoyo);
                StartCoroutine(ResetJump());
            }
        }
    }

    IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(jumpDuration * 2);
        jumping = false;
    }
}
