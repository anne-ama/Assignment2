using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{
    private void Awake() {
        Transform checkpointsTransform = transform.Find("CheckpointList");

        foreach (Transform checkpointSingleTransform in checkpointsTransform)
        {
            Debug.Log(checkpointSingleTransform);
            Checkpoint checkpointSingle = checkpointSingleTransform.GetComponent<Checkpoint>();
            checkpointSingle.SetTrackCheckpoints(this);
        }
    }

    public void PlayerThroughCheckpoint(Checkpoint checkpoint)
    {
        Debug.Log(checkpoint.transform.name);
    }
}
