using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Image fillImg;
    public float countdown = 10;
    private float currentTime;


    // Start is called before the first frame update
    void Start() {
        fillImg = GetComponent<Image>();
        currentTime = countdown;
    }

    // Update is called once per frame
    void Update() {
        if (currentTime > 0) {
            currentTime -= Time.deltaTime;
            fillImg.fillAmount = currentTime / countdown;
        }
        else {
            currentTime = countdown;
        }
    }
}
