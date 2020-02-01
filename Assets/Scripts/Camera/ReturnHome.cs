using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnHome : MonoBehaviour
{

    Vector3 startPosition, driftPosition;
    private Rigidbody rb;

    public float driftSeconds = 3.0f;
    private float driftTimer = 0;
    public float speed = 10.0f;
    private bool isDrifting = false;
    void Start() {
        rb = GetComponent<Rigidbody>();
        startPosition = Vector3.zero;
    }


    private void StartDrift() {
        isDrifting = true;
        driftTimer = 0;
        driftPosition = transform.position;
        rb.velocity = Vector3.zero;
    }

    private void StopDrift() {
        isDrifting = false;
        transform.position = startPosition;
        rb.velocity = Vector3.zero;
    }

    public void Move()
    {
        StartDrift();
        if (isDrifting) {
            driftTimer += Time.deltaTime * speed;
            if (driftTimer > driftSeconds) {
                StopDrift();
            }
            else {
                float ratio = driftTimer / driftSeconds;
                transform.position = Vector3.Lerp(driftPosition, startPosition, ratio);
            }
        }
    }
}
