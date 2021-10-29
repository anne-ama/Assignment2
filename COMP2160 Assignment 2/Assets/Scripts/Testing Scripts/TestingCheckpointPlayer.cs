using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingCheckpointPlayer : MonoBehaviour
{
    private Vector3 velocity = new Vector3(0,0,5);
    public float rotation = 30;
    public float speed = 1;

    // Update is called once per frame
    void Update()
    {
        //up, down, left and right (using input Axes script)
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        
        transform.Translate(velocity * Time.deltaTime*Vertical);
        float angle = rotation * Time.deltaTime;
        transform.Rotate(angle * Vector3.up*Horizontal);
    }
}
