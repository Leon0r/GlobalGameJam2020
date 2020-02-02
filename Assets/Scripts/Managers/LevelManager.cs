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

    private float timeLeft;
    public Timer timer;

    // Start is called before the first frame update
    void Awake() {
        timer.SetCountDown(timeLeft);
    }
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
        isMoving = (playerMovement.GetRigidBody().velocity != Vector2.zero);

        if (!isMoving) {
            Debug.Log("PERO QUE COJONES HACES AQUÍ");
            timer.CountDown();
            timeLeft -= Time.deltaTime;
        }
        else {
            isMoving = true;
            timeLeft = idleTime;
            timer.SetCountDown(idleTime);
        }

        if (timeLeft < 0) { 
            repairing = true;
            timer.SetCountDown(0);
        }

        for (int i = 0; i < platforms.Length; i++) {
            if (platforms[i].isRepairable && repairing) {
                platforms[i].UpdateState();
            }
        }

        lastPlayerPosition = playerMovement.transform.position;
    }

    public float GetTimeLeft() {
        return timeLeft;
    }
}
