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

     void Start()
    {
        gameOverPanel.SetActive(false);
    }

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

    public void ShowGameOver(bool win)
    {
        if (win)
        {
            gameOverText.text = winText;
        }
        else 
        {
            gameOverText.text = loseText;
        }
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        // reload the scene
        SceneManager.LoadScene(0);
        gameOverPanel.SetActive(false);
    }
}
