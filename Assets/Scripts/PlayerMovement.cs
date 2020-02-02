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
    Rigidbody2D rb;
    Vector3 initPos;

    //Animator
    [SerializeField] private Animator   animator;
    [SerializeField] private float      timeSitting = 2f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initPos = transform.position;
        characterController = GetComponent<CharacterController2D>();
    }

    public void Dead()
    {
        transform.position = initPos;
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
            animator.SetTrigger("IsJumping");
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
        animator.Play("JumpEnd");
    }

    //Move the character 
    void FixedUpdate()
    {
        characterController.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public Rigidbody2D GetRigidBody() {
        return rb;
    }
}
