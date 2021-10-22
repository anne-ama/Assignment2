using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    public Text timerText;
    private float timer;
    public Slider slider;

    void Update()
    {
        timer = Time.realtimeSinceStartup;
        timerText.text = "Timer: " + FormatTimeExtension.FormatTime(timer); 
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
