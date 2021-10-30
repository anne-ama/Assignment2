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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
}
