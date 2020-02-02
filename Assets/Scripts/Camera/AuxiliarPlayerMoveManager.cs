using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CameraController))]
[RequireComponent (typeof(ReturnHome))]
public class AuxiliarPlayerMoveManager : MonoBehaviour
{
    // Start is called before the first frame update
    bool movingX;
    bool movingY;

    CameraController cameraController;
    ReturnHome returnHome;
    PlayerMovement playerMovement;
    void Start() {
        returnHome = GetComponent<ReturnHome>();
        cameraController = GetComponent<CameraController>();
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update() {
        movingX = (Input.GetAxisRaw("HorizontalCamera") != 0);
        movingY = (Input.GetAxisRaw("VerticalCamera") != 0);
        if (!movingX && !movingY) {
            Camera.main.GetComponent<RangerMode>().SetRangerMode(false);
            returnHome.Move();
        }
        else
        {
            Camera.main.GetComponent<RangerMode>().SetRangerMode(true);
            cameraController.Move();
        }
    }
}
