using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]


public class CarMovement : MonoBehaviour
{
	private Rigidbody rb;
	private BoxCollider bc;

    //Driving Parameters
	private bool onGround = true;
    public LayerMask groundLayer;

	//Speed Parameters
	public float accelerationSpeed = 10;
	public float reverseSpeed = 5;
	public float maxSpeed = 40;
	public float maxAntiSpeed = 20;
    public float turningSpeed = 30;
    public float drag = 0.2F;

	private float lastDY;
	private	float dx;
	private float dy;
	public float turn = 4;
	//Directional Coding
	public GameObject wheelAll;
	public GameObject wheelSin;
	public GameObject wheelCos;
	public GameObject wheelTan;
	public GameObject body;
	private Vector3 forwardDirection;
	private Vector3 rightDirection;
	private Vector3 upDirection;
	//public GameObject Trigger;
	
	// Start is called before the first frame update
    void Start()
    {
		rb = gameObject.GetComponent<Rigidbody>();
		bc = gameObject.GetComponent<BoxCollider>();
		bc.isTrigger = true;
		rb.useGravity = true;
		rb.centerOfMass = new Vector3(0,0.1f,0);
		onGround = true;
    }
    // Update is called once per frame
    void Update()
    {
		forwardDirection = accelerationSpeed*(wheelAll.transform.position - wheelCos.transform.position);
		rightDirection = accelerationSpeed*(wheelAll.transform.position - wheelSin.transform.position);
		upDirection = accelerationSpeed*((wheelAll.transform.position+wheelSin.transform.position+wheelTan.transform.position+wheelCos.transform.position)/4-body.transform.position);
		//upDirection = Quaternion.Euler(rightDirection*-90)*forwardDirection*accelerationSpeed;
		if(onGround)
		{
			dx = Input.GetAxis("Horizontal");
			dy = Input.GetAxis("Vertical");
			if(rb.velocity.magnitude==0||(rb.velocity.magnitude<maxSpeed&&dy>0)||(rb.velocity.magnitude<maxAntiSpeed&&dy<0))
			{
				rb.AddRelativeForce(accelerationSpeed*Vector3.forward*dy);	
			}
			if(dy!=0)
			{
				transform.Rotate(Vector3.up*rb.velocity.magnitude*turningSpeed*dx/turn);//(turningSpeed*upDirection*dx*Time.deltaTime)(dz * turnRadius * (rb.velocity.magnitude / velocityTurnPower)

			}
			
			Debug.Log("Speed: "+rb.velocity.magnitude);
		}
		else
		{
			dx = 0;
			dy = 0;
		}
		Debug.DrawRay(this.transform.position, rightDirection, Color.red);
		Debug.DrawRay(this.transform.position, upDirection, Color.green);
		Debug.DrawRay(this.transform.position, forwardDirection, Color.blue);
    }
	void FixedUpdate()
	{
		
	}
	void OnDrawGizmos()
	{
		rb = gameObject.GetComponent<Rigidbody>();
		Gizmos.color = Color.yellow;
		Gizmos.DrawRay(this.transform.position, rb.velocity);

	}
	void OnTriggerStay(Collider other)// This needs to be edited to account for layers
	{

		GameObject collider = other.gameObject;
		
		if(groundLayer.Contains(collider))//Layers.Instance.player.Contains(collider)
		{
			isGrounded();
		}
		
	}
	void OnTriggerExit(Collider other)// This needs to be edited to account for layers
	{
		GameObject collider = other.gameObject;
		if(groundLayer.Contains(collider))
		{
			notGrounded();
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
	public float[] readOnlyXY()
	{
		float[] dxy = new float[2];
		dxy[0] = dx;
		dxy[1] = dy;
		return dxy;
	}
	public float readOnlyY()
	{
		return dy;
	}
	public float readOnlyX()
	{
		return dx;
	}
}
