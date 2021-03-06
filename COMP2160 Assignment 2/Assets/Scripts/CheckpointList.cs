using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointList : MonoBehaviour
{
    private List<CheckpointSingle> checkpointSingleList;
    public Transform checkpointList;
    private int currentIndex;
    private CheckpointSingle checkpointSingle;

    private void Awake() {
        Transform checkpointsTransform = checkpointList;
        checkpointSingleList = new List<CheckpointSingle>();
        foreach (Transform checkpointSingleTransform in checkpointsTransform)
        {
            Debug.Log(checkpointSingleTransform);
            checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();
            checkpointSingle.SetCheckpointList(this);
            checkpointSingleList.Add(checkpointSingle);
        }
        currentIndex = 0;
    }

    public void ActivateNextCheckpoint()
    {
        checkpointSingleList[currentIndex].isActive();
    }

    public void PlayerThroughCheckpoint(CheckpointSingle checkpointSingle)
    {
        if (checkpointSingleList.IndexOf(checkpointSingle) == currentIndex)
        {
            GameManager.Instance.CheckpointTimeRecord();
            
            //If this is the last checkpoint then indicate that it is the end of the game
            if (currentIndex == checkpointSingleList.Count - 1)
            {
                GameManager.Instance.Win();
            }
            else {
                currentIndex++;
                ActivateNextCheckpoint();
            }

        }
        else
        {
            checkpointSingle.notActive();
            Debug.Log("Wrong Checkpoint");
        }
    }
}
