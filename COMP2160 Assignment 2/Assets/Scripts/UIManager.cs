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

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
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
            ConvertTimeToText();
        }
        else 
        {
            gameOverText.text = loseText;
            ConvertTimeToText();
        }
        gameOverPanel.SetActive(true);
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void ConvertTimeToText()
    {
        int index = 1;
        foreach (float item in GameManager.Instance.CheckpointTimeList)
        {
            checkpointList = checkpointList + "Checkpoint " +
                 index + ": " + FormatTimeExtension.FormatTime(item) + "\n";
            index++;
        }
         checkpointTimes.text = checkpointList;
    }

}
