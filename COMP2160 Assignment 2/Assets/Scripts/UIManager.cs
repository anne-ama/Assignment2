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
        

        timerText.text = "Timer: " + FormatTime(timer); 
    }

    //put this into its own script
    private string FormatTime(float time) 
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);

        return string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
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
