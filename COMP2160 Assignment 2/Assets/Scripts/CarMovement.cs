using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]


public class CarMovement : MonoBehaviour
{
    public float accelerationSpeed;
    public float reverseSpeed;
    public float turningSpeed = 30;
    public float friction;
    public float gravity;
    public float drag;
	private bool onGround = true;
	private Rigidbody rb;

	
	// Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;
		rb.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(0,0,5);
		transform.Translate(velocity * Time.deltaTime*dy);
        float angle = turningSpeed * Time.deltaTime;
        transform.Rotate(angle * Vector3.up*dx);

    }
}
