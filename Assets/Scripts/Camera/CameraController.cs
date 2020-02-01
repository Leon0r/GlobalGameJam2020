using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Rigidbody rb;
    private float moveSpeed, maxSpeed = 8f;
    bool movingX;
    bool movingY;
    void Start() 
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = 50f;
    }
    public void Move()
    {
        movingX = (Input.GetAxisRaw("HorizontalCamera") != 0);
        movingY = (Input.GetAxisRaw("VerticalCamera") != 0);

        float _xAccel = 0, _yAccel = 0;
        _xAccel = Input.GetAxisRaw("HorizontalCamera");
        _yAccel = Input.GetAxisRaw("VerticalCamera");

        Vector2 vec = new Vector2(_xAccel, _yAccel);
        rb.AddForce(vec * moveSpeed);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        float newX = rb.velocity.x, newY = rb.velocity.y;

        if (!movingX)
            newX *= 0.9f;
        if (!movingY)
            newY *= 0.9f;

        rb.velocity = new Vector2(newX, newY);
    }

}
