using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceOnTrigger : MonoBehaviour
{
    public float force = 10f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement pm = other.gameObject.GetComponent<PlayerMovement>();
        if ( pm != null)
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, force), ForceMode2D.Impulse);
        }
    }
}
