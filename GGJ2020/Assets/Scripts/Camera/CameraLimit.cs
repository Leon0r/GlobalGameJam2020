using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimit : MonoBehaviour
{
    public Transform player;
    public Transform target;
    public float height = 2.5f;
    public float width = 5.5f;
    void LateUpdate() {
        float x = Mathf.Clamp(target.position.x, player.position.x - width, player.position.x + width);
        float y = Mathf.Clamp(target.position.y, player.position.y - height, player.position.y + height);
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
