using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Image fillImg;
    private float countdown = 3;
    private float currentTime = 0;


    // Start is called before the first frame update
    void Start() {
        fillImg = GetComponent<Image>();
        currentTime = countdown;
    }

    // Update is called once per frame
    public void CountDown() {
        if (currentTime > 0) {
            currentTime -= Time.deltaTime;
            fillImg.fillAmount = currentTime / countdown;
        }
        else {
            currentTime = countdown;
        }
    }

    public void SetCountDown(float cDown) {
        countdown = cDown;
        fillImg.fillAmount = (cDown> 1)? 1 : cDown;
    }
}
