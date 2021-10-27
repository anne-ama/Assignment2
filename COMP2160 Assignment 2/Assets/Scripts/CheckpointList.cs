using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointList : MonoBehaviour
{
    private List<CheckpointSingle> checkpointSingleList;
    public Transform checkpointList;
    private int nextCheckpointSingleIndex;
    static private bool correctCheckpoint;
    static public bool CorrectCheckpoint 
    {
        get 
        {
            
            return correctCheckpoint;
        }
    }

    private void Awake() {
        Transform checkpointsTransform = checkpointList;
        checkpointSingleList = new List<CheckpointSingle>();
        foreach (Transform checkpointSingleTransform in checkpointsTransform)
        {
            Debug.Log(checkpointSingleTransform);
            CheckpointSingle checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();
            checkpointSingle.SetCheckpointList(this);
            checkpointSingleList.Add(checkpointSingle);
        }
        nextCheckpointSingleIndex = 0;
        correctCheckpoint = false;
    }

    public void PlayerThroughCheckpoint(CheckpointSingle checkpointSingle)
    {
        if (checkpointSingleList.IndexOf(checkpointSingle) == nextCheckpointSingleIndex)
        {
            //Correct checkpoint passed through
            Debug.Log("Correct Checkpoint");
            //this loops back to 0 however this may be unnecessary
            nextCheckpointSingleIndex = (nextCheckpointSingleIndex + 1) % checkpointSingleList.Count;
            correctCheckpoint = true;
        }
        else
        {
            //wrong checkpoint passed through
            Debug.Log("Wrong Checkpoint");
            correctCheckpoint = false;
        }
    }
}
