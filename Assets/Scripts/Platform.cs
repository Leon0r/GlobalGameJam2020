using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

// TODO: 
//       Estudiar como funca iTween.

public class Platform : MonoBehaviour
{
    // Private 
    BoxCollider2D activation; // PLatform Collider (destroyed or not effect)
    Animator anim;

    // Variables y cosas para el giro
    private float anglesToTurn;
    private float anglesLeft;
    private bool isTurning;
    private int turningDir;
    private float timeLeft;

    // Cosas para resetear las plataformas
    private Vector3 posOr; // Posicion original para resetear
    private Quaternion rotOr; // Rotación original para resetar

    private bool insideViewPort;

    // Variables públicas
    [System.Serializable]
    public enum RotationDir { Horario, Antihorario };

    [System.Serializable]
    public enum Axis { x, y, z };

    [Header("Repairable")]
    public bool isRepairable;

    [Header("Vertical")]
    public bool movesVert;
    public System.Int32 distanceY;
    public float velVert;      // El tiempo que tarda en moverse

    [Header("Horizontal")]
    public bool movesHorz;
    public System.Int32 distanceX;
    public float velHorz;

    [Header("Diagonal")]
    public bool movesDiagonally;
    public System.Int32 distanceDiagonalX;
    public System.Int32 distanceDiagonalY;
    public float velDiag;

    [Header("Rotación")]
    public bool rotates;
    public RotationDir rotationDirection;
    public Axis rotationAxis;

    public uint amount;
    public float angularVel;
    public float timeBetweenRotations;

    // Start is called before the first frame update
    void Start()
    {
        insideViewPort = false;
        posOr = transform.position;
        rotOr = transform.rotation;

        // Init rotation
        if (rotates)
        {
            anglesToTurn = 360.0f / amount;
            isTurning = false;

            if (rotationDirection == RotationDir.Horario)
            {
                turningDir = 1;
            }
            else
            {
                turningDir = -1;
            }
        }

        // To check if the platform has a collider...
        activation = transform.gameObject.GetComponent<BoxCollider2D>();

        // If there is no collider show error and add one to avoid execution errors
        if (activation == null)
        {
            Debug.LogError("There is no collider in this platform: " + transform.gameObject.name + ".");
        }

        // Init repairing
        if (isRepairable)
        {
            // Save animator to play animations for destroying and repairing
            anim = transform.gameObject.GetComponent<Animator>();

            // Checking if there is an animator.
            if (anim == null)
            {
                Debug.LogError("There is no animator nor animation attached to this platform: " + transform.gameObject.name + ".");
            }

            // Deactivate component
            activation.enabled = false;
        }
        // Si no es reparable, significa que va a estar activada siempre, así que establecemos los diferentes movimientos
        else if (movesHorz)
        {
            HorizMove();
        }
        else if (movesVert)
        {
            VertMove();
        }
        else if (movesDiagonally)
        {
            DiagMove();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Rotating movement
        if (activation.enabled) // If collider is active, do the thing
        {
            timeLeft -= Time.deltaTime;
            if ((timeLeft < 0) && !isTurning) // Activate rotation movement
            {
                isTurning = true;
                anglesLeft = anglesToTurn;
                Invoke("TurnSlot", 0.1f);
            }
        }
    }

    /////////////////////////// Destruction and Repairing ////////////////////////////////

    void Destroy()
    {
        // De momento esto es un placeholder, cuando estén las animaciones de destrucción de las plataformas toca cambiarlo
        // Meter también los eventos de sonido aquí(?)
        // anim.Play();
        activation.enabled = false;

        if (movesHorz || movesVert)
        {
            iTween.Stop(gameObject); // Stop animation
        }

        // Reset
        transform.position = posOr;
        transform.rotation = rotOr;
    }

    public void UpdateState()
    {
        //Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        //insideViewPort = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        insideViewPort = Camera.main.IsObjectVisible(GetComponent<SpriteRenderer>());
        if (insideViewPort) {
            if (!activation.enabled) {
                Repair();
            }
        }
        else {
            if (activation.enabled)
            {
                Destroy();
            }
        }
    }

    public void Repair()
    {
        // anim.Play();
        activation.enabled = true;

        if (movesHorz)
        {
            HorizMove();
        }

        if (movesVert)
        {
            VertMove();
        }

        if (movesDiagonally)
        {
            DiagMove();
        }
    }


    //////////////////////////////////// Movement ////////////////////////////////////////
    
    void HorizMove()
    {
        iTween.MoveTo(gameObject, iTween.Hash("x", transform.position.x + distanceX,
            "time", Math.Abs(distanceX / velHorz),
            "easeType", "linear", 
            "loopType", "pingPong"));
    }

    void VertMove()
    {
        iTween.MoveTo(gameObject, iTween.Hash("y", transform.position.y + distanceY,
            "time", Math.Abs(distanceY / velVert),
            "easeType", "linear",
            "loopType", "pingPong"));
    }

    void DiagMove()
    {
        float hypotenuse = (float)Math.Sqrt((Math.Pow(distanceDiagonalX, 2) + Math.Pow(distanceDiagonalY, 2)));
        iTween.MoveTo(gameObject, iTween.Hash("x", distanceDiagonalX,
            "y", distanceDiagonalY,
            "time", Math.Abs(hypotenuse / velDiag),
            "easeType", "linear",
            "loopType", "pingPong"));
    }

    // Movidas de rotación 
    void TurnSlot()
    {
        Vector3 rot = new Vector3(0, 0, 0);

        switch (rotationAxis)
        {
            case Axis.x:
                rot.x = (angularVel * turningDir);
                break;
            case Axis.y:
                rot.y = (angularVel * turningDir);
                break;
            case Axis.z:
                rot.z = (angularVel * turningDir);
                break;
        }

        if(anglesLeft > 0)
        {
            anglesLeft -= Mathf.Abs(angularVel);
            if(anglesLeft < 0)
            {
                switch (rotationAxis)
                {
                    case Axis.x:
                        rot.x = (angularVel * turningDir);
                        break;
                    case Axis.y:
                        rot.y = (angularVel * turningDir);
                        break;
                    case Axis.z:
                        rot.z = (angularVel * turningDir);
                        break;
                }
            }
            transform.Rotate(rot);

            Invoke("TurnSlot", 0.01f);
        }
        else
        {
            isTurning = false;
            // Init timer
            timeLeft = timeBetweenRotations;
        }
    }
}
