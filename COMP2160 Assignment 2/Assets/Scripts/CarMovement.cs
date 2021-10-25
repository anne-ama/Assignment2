using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]


public class CarMovement : MonoBehaviour
{
    public float accelerationSpeed = 10;
    public float reverseSpeed = 5;
    public float turningSpeed = 30;
    public float friction;
    public float gravity;
    public float drag;
	private bool onGround = true;
	private Rigidbody rb;
	private Vector3 Vec;



	
	// Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        //rb.isKinematic = true;
		//rb.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");
        //Vector3 position = MousePosition();
        //Vec = position;
		Vector3 velocity = new Vector3(0,0,20);
		transform.Translate(velocity * Time.deltaTime*dy);
        float angle = turningSpeed * Time.deltaTime;
		
		if(dy!=0)
		{
		transform.Rotate(angle * Vector3.up*dx);

		}
    }
    void FixedUpdate()
    {
        //Vector3 direction = Vec - this.transform.position;
		//rb.velocity = rb.velocity + direction*Time.fixedDeltaTime;
		//rb.AddForce(direction);
    }
    private Vector3 MousePosition()
    {
        // use raycasting to turn mouse position into position on the board
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float t;
        plane.Raycast(ray, out t);
        return ray.GetPoint(t);
    }

	/*void FixedUpdate()
    {
        Vector3 direction = Vec - this.transform.position;
        rb.velocity = rb.velocity + direction*Time.fixedDeltaTime;
    }*/

}
