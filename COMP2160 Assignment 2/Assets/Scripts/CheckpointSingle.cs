using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSingle : MonoBehaviour
{ 
    private void Start() {
        notActive();
    }

    private void OnTriggerEnter(Collider other) 
    {
        GameObject collider = other.gameObject;
        if (Layers.Instance.checkpoint.Contains(collider))
        {
            isActive();
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        notActive();
    }

    private void isActive()
    {
        GetComponent<Renderer>().material.color = new Color(1.0f, 0.8f, 0.4f, 1.0f);
        Debug.Log("Something is detected");
    }

    private void notActive()
    {
        GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.4f, 1.0f);
        // Debug.Log("Leaving");
    }

}
