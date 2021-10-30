using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointList : MonoBehaviour
{
    private List<CheckpointSingle> checkpointSingleList;
    private List<float> checkpointTimeList;
    public Transform checkpointList;
    private int currentIndex;
    private CheckpointSingle checkpointSingle;

    private void Awake() {
        //Adding checkpoints to the list to track 
        Transform checkpointsTransform = checkpointList;
        checkpointSingleList = new List<CheckpointSingle>();
        //Create a new time list to record times 
        checkpointTimeList = new List<float>();

        //Cycle through and add 
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
        //if the index of the one we are passing through is the correct index
        if (checkpointSingleList.IndexOf(checkpointSingle) == currentIndex)
        {
            //Correct checkpoint passed through
            Debug.Log("Correct Checkpoint");

             //Log the time that it passes through the checkpoint
            checkpointTimeList.Add(Time.realtimeSinceStartup);
            Debug.Log(Time.realtimeSinceStartup);

            //If this is the last checkpoint then indicate that it is the end of the game
            if (currentIndex == checkpointSingleList.Count - 1)
            {
                // currentIndex = checkpointSingleList.Count;
                Debug.Log("Game Won!");
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
