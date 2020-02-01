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
    void Start() {
        returnHome = GetComponent<ReturnHome>();
        cameraController = GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update() {
        movingX = (Input.GetAxisRaw("Horizontal") != 0);
        movingY = (Input.GetAxisRaw("Vertical") != 0);
        if (!movingX && !movingY) {
            returnHome.Move();
        }
        else {
            cameraController.Move();
        }
    }
}
