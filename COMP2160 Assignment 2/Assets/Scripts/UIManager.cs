using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Singleton
    static private UIManager instance;
    static public UIManager Instance 
    {
        get 
        {
            if (instance == null) 
            {
                Debug.LogError("There is no UIManager in the scene.");
            }            
            return instance;
        }
    }
    //Timer UI fields
    public Text timerText;
    private float timer;

    //HealthBar UI fields
    public Slider slider;

    //GameOver UI fields
    public GameObject gameOverPanel;
    public Text gameOverText;
    private string winText = "YOU WIN!";
    private string loseText = "YOU LOSE!";
    public Text checkpointTimes; 
    private string checkpointList = "";

    void Awake() 
    {
        if (instance != null)
        {
            // if there is already a UI manager in the scene, then destroy this one
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        timer = Time.realtimeSinceStartup;
        timerText.text = "Timer: " + FormatTimeExtension.FormatTime(timer);
    }

    private void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    private void SetHealth(int health)
    {
        slider.value = health;
    }

    public void ShowGameOver(bool win)
    {
        if (win)
        {
            gameOverText.text = winText;
            //checkpoint text should go here
            ConvertTimeToText();
        }
        else 
        {
            gameOverText.text = loseText;
            //checkpoint text should go here
            ConvertTimeToText();
        }
        gameOverPanel.SetActive(true);
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
        gameOverPanel.SetActive(false);
    }

    public void ConvertTimeToText()
    {
        int i = 1;
        foreach (float item in GameManager.Instance.CheckpointTimeList)
        {
            checkpointList = checkpointList + "Checkpoint " + i + ": " + FormatTimeExtension.FormatTime(item) + "\n";
            i++;
        }
         checkpointTimes.text = checkpointList;
    }

}
