using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;

    public float smoothSpeed = 0.5f;

    public Vector3 offset = new Vector3(0, 0.0f, -10.0f);

    void LateUpdate() {
        Vector3 newPosition = player.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, newPosition, smoothSpeed);
        transform.position = smoothPosition;
    }
}
