using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceOnTrigger : MonoBehaviour
{
    public float force = 10f;
    private ParticleSystem particle = null;
    private bool isActive = false;

    void Start()
    {
        particle = transform.parent.GetComponent<ParticleSystem>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement pm = other.gameObject.GetComponent<PlayerMovement>();
        if ( pm != null)
        {
            AkSoundEngine.PostEvent("Vapor", gameObject);
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, force), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerMovement pm = other.gameObject.GetComponent<PlayerMovement>();
        if (pm != null)
        {
            AkSoundEngine.PostEvent("VaporOff", gameObject);
        }
    }

    void StartSteam()
    {

        particle.Play();
    }
    void StopSteam()
    {

        particle.Stop();
    }
}
