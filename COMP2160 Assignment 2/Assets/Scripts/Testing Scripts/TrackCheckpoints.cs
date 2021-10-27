using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{
    // private List<Checkpoint> checkpointsList;
    // private int nextCheckpointSingleIndex;
    // private void Awake() {
    //     Transform checkpointsTransform = transform.Find("CheckpointList");

    //     foreach (Transform checkpointSingleTransform in checkpointsTransform)
    //     {
    //         Debug.Log(checkpointSingleTransform);
    //         Checkpoint checkpointSingle = checkpointSingleTransform.GetComponent<Checkpoint>();
    //         checkpointSingle.SetTrackCheckpoints(this);
    //         checkpointsList.Add(checkpointSingle);
    //     }

    //     nextCheckpointSingleIndex = 0;
    // }

    // public void PlayerThroughCheckpoint(Checkpoint checkpoint)
    // {
    //     // Debug.Log(checkpoint.transform.name);
    //     if (checkpointsList.IndexOf(checkpoint) == nextCheckpointSingleIndex)
    //     {
    //         Debug.Log("Correct checkpoint");
    //         //correct checkpoint
    //         //modulo supports multiple laps
    //         nextCheckpointSingleIndex = (nextCheckpointSingleIndex + 1) % checkpointsList.Count;
    //     }
    //     else
    //     {
    //         //wrong checkpoint
    //         Debug.Log("Wrong checkpoint");
    //     }
    // }
}
