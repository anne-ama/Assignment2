using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]


public class CarMovement : MonoBehaviour
{
    public float accelerationSpeed = 10;
	public float reverseSpeed = 5;
	public float maxSpeed = 40;
	public float maxAntiSpeed = 20;
    //public float reverseSpeed = 5;
    public float turningSpeed = 30;
    public float drag = 0.2F;
	private bool onGround = true;
	private Rigidbody rb;
	private float lastDY;
	private	float dx;
	private float dy;
	//I am coding the wheels into the game so i can get which direction is forward. And i have named the wheels into the game based on where they would be on a unit circle
	public GameObject wheelAll;
	public GameObject wheelSin;
	public GameObject wheelCos;
	public GameObject wheelTan;
	private Vector3 forwardDirection;
	private BoxCollider bc;
	// Start is called before the first frame update
    void Start()
    {
		rb = gameObject.GetComponent<Rigidbody>();
		bc = gameObject.GetComponent<BoxCollider>();
		rb.useGravity = true;
		onGround = true;
    }
    // Update is called once per frame
    void Update()
    {
		forwardDirection = accelerationSpeed*(wheelAll.transform.position - wheelCos.transform.position);
		if(Input.GetKeyDown(KeyCode.Space))//test function that will be removed later
		{
			if(onGround)
			{
				onGround = false;
			}
			else
			{
				onGround = true;
			}
		}
		if(onGround)
		{
			dx = Input.GetAxis("Horizontal");
			dy = Input.GetAxis("Vertical");
			transform.Rotate(turningSpeed*Vector3.up*dx*Time.deltaTime);
			
			//if(dy>0)
			if(dy!=0)
			{
				float mag = rb.velocity.magnitude;
				if(dy>0)
				{
					if(mag<maxSpeed)
					{
						rb.AddRelativeForce(accelerationSpeed*Vector3.forward*dy);
						rb.AddRelativeForce(drag*Vector3.back*dy);					
					}

				}
				else
				{
					if(mag>-maxAntiSpeed)
					{
						rb.AddRelativeForce(reverseSpeed*Vector3.back*-dy);
						rb.AddRelativeForce(drag*Vector3.back*dy);
					}
				}
				if(mag>-5&&mag<5)
				{
					//Debug.Log("Checkpoint");
					lastDY = dy;	
				}

				rb.AddForce(- rb.velocity);
				rb.AddRelativeForce(Vector3.forward*mag*lastDY);

				//rb.AddRelativeForce(accelerationSpeed*Vector3.forward*dy);
				
				//Vector3 Cancellation = rb.velocity-forwardDirection;
				Debug.Log(mag+"(, )"+lastDY+"(, )"+dy);
			}
			
		}
		else
		{
			dx = 0;
			dy = 0;
		}
		Debug.DrawRay(this.transform.position, forwardDirection, Color.green);
		
    }
	void OnTriggerEnter(Collider other)// This needs to be edited to account for layers
	{
		//GameObject collider = other.gameObject;
		//if(Layers.pl.Terr
		//if(other.name=="Terrain")
		//{
		//	isGrounded();
		//	Debug.Log("True");
		//}
	}
	void OnTriggerExit(Collider other)// This needs to be edited to account for layers
	{
		notGrounded();
		//LayerMask.LayerToName(
		if(other.name=="Terrain")
		{
			Debug.Log("False");
		}
	}
	public void isGrounded()
	{
		onGround = true;
	}
	public void notGrounded()
	{
		onGround = false;
	}

	public Vector3 ReadOnlyDir()
	{
		return forwardDirection;//.normalized
	}
	public float readOnlyX()
	{
		return dx;
	}
	public float readOnlyY()
	{
		return dy;
	}

	
	
	
	//public Vector3[][] 
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
			//Debug.Log((wheelCos.transform.position - wheelAll.transform.position).magnitude);
			//cameraPosition = 4*(wheelCos.transform.position - wheelAll.transform.position);
			//cameraDistance = distance + dy;
		//Debug.Log(Physics.gravity);
//		Debug.DrawRay(this.transform.position, cameraPosition, Color.red);
	//		Debug.Log(
	
//		cameraPosition = cameraDistance*(-1*forwardDirection.normalized);
	//private float speed = 0;
	//private Vector3 backwardDirection;
	//private Vector3 cameraPosition;
	//public float distance = 4;
	//		float cameraDistance = distance;
	//public float cameraPosition = 5;

	
}
