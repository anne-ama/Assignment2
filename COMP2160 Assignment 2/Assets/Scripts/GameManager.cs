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

        checkpointTimeList = new List<float>();
    }

    void Start()
    {
        
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
        //Log the time that it passes through the checkpoint
        checkpointTimeList.Add(Time.realtimeSinceStartup);
        Debug.Log(Time.realtimeSinceStartup);
    }
}
