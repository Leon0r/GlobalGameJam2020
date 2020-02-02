using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            //other.gameObject.GetComponent<PlayerMovement>().Dead();
            levelManager.ResetPlatforms();
        }
    }
}
