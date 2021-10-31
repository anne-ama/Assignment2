using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton
    static private GameManager instance;
    static public GameManager Instance 
    {
        get 
        {
            if (instance == null)
            {
                Debug.LogError("There is no GameManager instance in the scene.");
            }
            return instance;
        }
    }

    private List<float> checkpointTimeList;
    public List<float> CheckpointTimeList
    {
        get
        {
            return checkpointTimeList;
        }
    }
    // private int i;

    void Awake()
    {
        if (instance != null) 
        {
            // destroy duplicates of game manager
            Destroy(gameObject);            
        }
        else 
        {
            instance = this;
        }  
    }

    void Start()
    {
        checkpointTimeList = new List<float>();
        // i = 0;
    }

    void Update()
    {
        
    }

    public void Die()
    {
        Debug.Log("Game Lost!");
        UIManager.Instance.ShowGameOver(false);
    }

    public void Win()
    {
        Debug.Log("Game Won!");
        UIManager.Instance.ShowGameOver(true);
    }

    public void CheckpointTimeRecord()
    {
        checkpointTimeList.Add(Time.realtimeSinceStartup);
        // Debug.Log(FormatTimeExtension.FormatTime(checkpointTimeList[i]));
        // i++;
    }
}
