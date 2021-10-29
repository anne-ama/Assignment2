using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointList : MonoBehaviour
{
    private List<CheckpointSingle> checkpointSingleList;
    private List<float> checkpointTimeList;
    public Transform checkpointList;
    private int nextCheckpointSingleIndex;
    private CheckpointSingle checkpointSingle;

    private void Awake() {
        //Adding checkpoints to the list to track 
        Transform checkpointsTransform = checkpointList;
        checkpointSingleList = new List<CheckpointSingle>();
        checkpointTimeList = new List<float>();
        foreach (Transform checkpointSingleTransform in checkpointsTransform)
        {
            Debug.Log(checkpointSingleTransform);
            checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();
            checkpointSingle.SetCheckpointList(this);
            checkpointSingleList.Add(checkpointSingle);
        }
        nextCheckpointSingleIndex = 0;
    }

    public void PlayerThroughCheckpoint(CheckpointSingle checkpointSingle)
    {
        if (checkpointSingleList.IndexOf(checkpointSingle) == nextCheckpointSingleIndex)
        {
            //Correct checkpoint passed through
            Debug.Log("Correct Checkpoint");
            //this loops back to 0 however this may be unnecessary
            // nextCheckpointSingleIndex = (nextCheckpointSingleIndex + 1) % checkpointSingleList.Count;
            nextCheckpointSingleIndex++;
            checkpointSingle.isActive();
            checkpointTimeList.Add(Time.realtimeSinceStartup);
            Debug.Log(Time.realtimeSinceStartup);

            if (nextCheckpointSingleIndex >= checkpointSingleList.Count)
            {
                Debug.Log("last checkpoint");
            }
        }
        else
        {
            checkpointSingle.notActive();
            //wrong checkpoint passed through
            Debug.Log("Wrong Checkpoint");
        }
    }
}
