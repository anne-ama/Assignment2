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
                 // if there is already a UI manager in the scene, then destroy this one
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
    private float timer;
    public float Timer
    {
        get
        {
            return timer;
        }
    }
    
    private int index;

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

    public void Start()
    {
        checkpointTimeList = new List<float>();
        timer = 0;
    }

    public void Update() {
        timer += Time.deltaTime;
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
        checkpointTimeList.Add(timer);
    }
}
