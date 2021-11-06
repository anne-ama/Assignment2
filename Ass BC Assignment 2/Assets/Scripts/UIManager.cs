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

    //HealthBar UI fields
    public Slider slider;

    //GameOver UI fields
    public GameObject gameOverPanel;
    public Text gameOverText;
    private string winText = "YOU WIN!";
    private string loseText = "YOU LOSE!";
    public Text checkpointTimes; 
    private string checkpointList = "";
    private int index;

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

    public void Update()
    {
        timerText.text = "Timer: " + 
            FormatTimeExtension.FormatTime(GameManager.Instance.Timer);   
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
            ConvertTimeToText();
        }
        else 
        {
            gameOverText.text = loseText;
            checkpointTimes.text = "Incomplete";
        }
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private void ConvertTimeToText()
    {
        index = 1;
        foreach (float time in GameManager.Instance.CheckpointTimeList)
        {
            checkpointList = checkpointList + "Checkpoint " +
                index + ": " + FormatTimeExtension.FormatTime(time) + 
                    "\n";
            index++;
        }
        checkpointTimes.text = checkpointList;
    }
}
