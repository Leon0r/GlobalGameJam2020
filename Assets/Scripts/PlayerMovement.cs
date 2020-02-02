using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float runSpeed = 40f;

    CharacterController2D characterController;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    Rigidbody2D rb;
    Vector3 initPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initPos = transform.position;
        characterController = GetComponent<CharacterController2D>();
    }

    //Get the input from the player
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
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

    //Move the character 
    void FixedUpdate () {
        characterController.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
	}

    /// <summary>
    /// Reset player's position when hitting a deadzone. Basically, a respawn.
    /// </summary>
    public void Dead()
    {
        // Later we should add lives and a live-counter somewhere
        transform.position = initPos;
    }

    public Rigidbody2D GetRigidBody() {
        return rb;
    }
}
