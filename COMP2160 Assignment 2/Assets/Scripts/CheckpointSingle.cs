using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSingle : MonoBehaviour
{ 
    private CheckpointList checkpointList;
    public Color activeColor = new Color(1.0f, 0.8f, 0.4f, 1.0f);
    public Color inactiveColor = new Color(0.5f, 0.5f, 0.4f, 1.0f);

    private void Start() {
        notActive();
    }

    private void OnTriggerEnter(Collider other) 
    {
        GameObject collider = other.gameObject;
        if (Layers.Instance.checkpoint.Contains(collider))
        {
            //probably call is active from the other script??
            isActive();
            checkpointList.PlayerThroughCheckpoint(this);

        }
    }

    private void OnTriggerExit(Collider other) 
    {
        notActive();
    }

    public void isActive()
    {
        GetComponent<Renderer>().material.color = activeColor;
    }

    public void notActive()
    {
        GetComponent<Renderer>().material.color = inactiveColor;
    }

    public void SetCheckpointList(CheckpointList checkpointList)
    {
        this.checkpointList = checkpointList;
    }
}
