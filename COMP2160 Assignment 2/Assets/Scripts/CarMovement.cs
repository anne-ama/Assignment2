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
    public float drag = 2;
	private bool onGround = true;
	private Rigidbody rb;
	private Vector3 velocity = Vector3.forward;
    //private State state;
	private float dx;
	private float dy;
	public BoxCollider groundCollider;



	// Start is called before the first frame update
    void Start()
    {
		//state = State.OnGround;
		rb = gameObject.GetComponent<Rigidbody>();
		rb.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
		if(onGround)
		{
			dx = Input.GetAxis("Horizontal");
			dy = Input.GetAxis("Vertical");
			if(dy!=0)
			{
				transform.Rotate(turningSpeed*Vector3.up*dx*Time.deltaTime);
				rb.AddForce(accelerationSpeed*Vector3.forward*dy);
				rb.AddForce(drag*Vector3.back*dy);
			}
		}
		else
		{
			dx = 0;
			dy = 0;
		}
		
		
    }
   /*void FixedUpdate()
    {
		if(Input.GetAxis("Vertical")!=0)
		{
		}
		rb.velocity = rb.velocity + velocity*Time.fixedDeltaTime;
		rb.AddForce(velocity);
    }*/
	void OnTriggerEnter(Collider other)
	{
		onGround = true;
	}
	void OnTriggerExit(Collider other)
	{
		onGround = false;
	}
	
		/*switch (state)
        {
            case State.OnGround:
					dx = Input.GetAxis("Horizontal");
					dy = Input.GetAxis("Vertical");
					if(dy!=0)
					{
						transform.Rotate(turningSpeed*Vector3.up*dx*Time.deltaTime);
					}
					Debug.Log("State = Rise");
					state = State.InAir;
            break;
            case State.InAir:
					dx = Input.GetAxis("Horizontal");
					dy = Input.GetAxis("Vertical");
					if(dy!=0)
					{
						transform.Rotate(turningSpeed*Vector3.up*dx*Time.deltaTime);
					}
					Debug.Log("State = Rise");
					state = State.UpSideDown;
                  break;
            case State.UpSideDown:
                
					dx = Input.GetAxis("Horizontal");
					dy = Input.GetAxis("Vertical");
					if(dy!=0)
					{
						transform.Rotate(turningSpeed*Vector3.up*dx*Time.deltaTime);
					}
					Debug.Log("State = Rise");
					state = State.OnGround;
                
				break;
		}*/	
	/*private enum State {
        OnGround,
        InAir,
		UpSideDown
    }*/

}
