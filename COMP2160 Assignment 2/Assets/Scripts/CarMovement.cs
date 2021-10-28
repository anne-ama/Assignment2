using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]


public class CarMovement : MonoBehaviour
{
    public float accelerationSpeed = 10;
	public float maxSpeed = 40;
    public float reverseSpeed = 5;
    public float turningSpeed = 30;
    public float drag = 0.2F;
	private bool onGround = true;
	private Rigidbody rb;
	private float lastDY;
	
	//I am coding the wheels into the game so i can get which direction is forward. And i have named the wheels into the game based on where they would be on a unit circle
	public GameObject wheelAll;
	public GameObject wheelSin;
	public GameObject wheelCos;
	public GameObject wheelTan;
	private Vector3 forwardDirection;
	
	private float speed = 0;
	

	// Start is called before the first frame update
    void Start()
    {
		rb = gameObject.GetComponent<Rigidbody>();
		rb.useGravity = true;
		Debug.Log(Physics.gravity);
    }

    // Update is called once per frame
    void Update()
    {
		float dx;
		float dy;
		forwardDirection = accelerationSpeed*(wheelAll.transform.position - wheelCos.transform.position);
		if(onGround)
		{
			dx = Input.GetAxis("Horizontal");
			dy = Input.GetAxis("Vertical");
			transform.Rotate(turningSpeed*Vector3.up*dx*Time.deltaTime);
			if(dy!=0)
			{
				rb.AddRelativeForce(accelerationSpeed*Vector3.forward*dy);
				float mag = rb.velocity.magnitude;
				
				Vector3 Cancellation = rb.velocity-forwardDirection;
				if(mag>maxSpeed)
				{
					mag=maxSpeed;
				}
				if(mag<-maxSpeed)
				{
					mag=-maxSpeed;
				}
				if(mag>-5&&mag<5)
				{
					Debug.Log("Checkpoint");
					lastDY = dy;
					
				}

				Debug.Log(mag+"(, )"+lastDY+"(, )"+dy);
				rb.AddForce(- rb.velocity);
				rb.AddRelativeForce(Vector3.forward*mag*lastDY);
				rb.AddRelativeForce(drag*Vector3.back*dy);

			}
			
		}
		else
		{
			dx = 0;
			dy = 0;
		}
		Debug.DrawRay(this.transform.position, forwardDirection, Color.green);
		
    }
	void OnTriggerEnter(Collider other)
	{
		onGround = true;
	}
	void OnTriggerExit(Collider other)
	{
		onGround = false;
	}
	

	public Vector3 ReadOnlyDir()
	{
		return forwardDirection;
	}
//OldCode
    //private State state;
		//state = State.OnGround;
	//private BoxCollider groundCollider;

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
	   /*void FixedUpdate()
    {
		if(Input.GetAxis("Vertical")!=0)
		{
		}
		rb.velocity = rb.velocity + velocity*Time.fixedDeltaTime;
		rb.AddForce(velocity);
    }*/
			/*speed = speed + accelerationSpeed*dy*Time.deltaTime;
			
			if(speed>maxSpeed)
			{
				speed = maxSpeed;
			}
			if(speed<-maxSpeed)
			{
				speed = -maxSpeed;
			}
			Debug.Log(speed);
			transform.Translate(Vector3.forward*speed*Time.deltaTime);
		*/
				//rb.AddForce(forwardDirection*lastDY - rb.velocity);

				//Debug.Log(velocityAngle);
				//Debug.Log(Quaternion.Euler(forwardDirection.x, forwardDirection.y, forwardDirection.z));

					//Debug.Log("Forwards: " + forwardDirection + "; Velocity: "+rb.velocity+"; Subtraction: " + (forwardDirection - rb.velocity) +";");
				//float velocityAngle = Vector3.Angle(forwardDirection, rb.velocity);

	
}
