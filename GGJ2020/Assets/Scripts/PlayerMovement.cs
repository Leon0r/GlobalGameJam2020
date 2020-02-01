﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float runSpeed = 40f;

    CharacterController2D characterController;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    private void Start()
    {
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
}
