using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float runSpeed = 40f;

    CharacterController2D characterController;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    Vector3 initPos;

    //Animator
    [SerializeField] private Animator   animator;
    [SerializeField] private float      timeSitting = 2f;


    private void Start()
    {
        initPos = transform.position;
        characterController = GetComponent<CharacterController2D>();
    }

    //Get the input from the player
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if(horizontalMove == 0)
        {
            timeSitting -= Time.deltaTime;
            if(timeSitting <= 0)
            {
                timeSitting = 2f;
                animator.SetBool("Sitting", true);
            }
        }

        else if (animator.GetBool("Sitting") && horizontalMove == 0)
        {
            animator.SetBool("Sitting", false);
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    //Cuando el personaje toca el suelo
    public void OnLanding()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("JumpAir") || animator.GetCurrentAnimatorStateInfo(0).IsName("JumpAir"))
        {
            animator.Play("JumpEnd");
        }
        animator.SetBool("IsJumping", false);
    }

    //Move the character 
    void FixedUpdate()
    {
        characterController.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
