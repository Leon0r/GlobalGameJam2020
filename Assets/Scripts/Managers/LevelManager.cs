using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [UnityEngine.Tooltip("Group of level platforms")]
    public Platform[] platforms;
    public PlayerMovement playerMovement;
    public float idleTime;

    // Control of the player movement
    private bool isMoving;
    private bool repairing;
    private Vector3 lastPlayerPosition;

    // Timer y cosos
    private float timeLeft;

    // Start is called before the first frame update
    void Start() {
        lastPlayerPosition = playerMovement.transform.position;
        repairing = false;
    }

    public void ResetPlatforms()
    {
        for (int i = 0; i < platforms.Length; i++)
        {
            platforms[i].ResetPlatform();
        }
    }

    // Update is called once per frame
    void Update() {
        isMoving = (lastPlayerPosition != playerMovement.transform.position);

        if (!isMoving) {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            timeLeft = idleTime;
        }

        if (timeLeft < 0) { 
            repairing = true;
        }

        for (int i = 0; i < platforms.Length; i++) {
            if (platforms[i].isRepairable && repairing) {
                platforms[i].UpdateState();
            }
        }

        lastPlayerPosition = playerMovement.transform.position;
    }
}
