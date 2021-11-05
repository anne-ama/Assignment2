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
	private float halfSpeed;
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
	
	
	private Vector3 xDir;//rightDirection
	private Vector3 yDir;//upDirection
	private Vector3 zDir;//forwardDirection
	
	private Vector3 altVel;
	private Vector3 dir;
	//Alternate velocity. This will flip the Velocity's "rightDirection" value, giving an alternate
	private float altAngle;
	
	public bool gameOn = true;
	
	
	//public GameObject Trigger;
	
	// Start is called before the first frame update
    void Start()
    {
		halfSpeed = accelerationSpeed/2;
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
		if(gameOn)
		{
			dx = Input.GetAxis("Horizontal");
			dy = Input.GetAxis("Vertical");
			dir = dy*zDir;
			xDir = (wheelAll.transform.position - wheelSin.transform.position).normalized;
			yDir = ((wheelAll.transform.position+wheelSin.transform.position+wheelTan.transform.position+wheelCos.transform.position)/4-transform.position).normalized;
			zDir = (wheelAll.transform.position - wheelCos.transform.position).normalized;
			if(onGround&&dy!=0)
			{
				transform.Rotate(turningSpeed*yDir*dx*Time.deltaTime);//(turningSpeed*upDirection*dx*Time.deltaTime)(dz * turnRadius * (rb.velocity.magnitude / velocityTurnPower)			
			}
		}
    }
	void FixedUpdate()
	{
		if(gameOn)
		{
			if(onGround&&(rb.velocity.magnitude==0||(rb.velocity.magnitude<maxSpeed&&dy>0)||(rb.velocity.magnitude<maxAntiSpeed&&dy<0)))
			{
				/*//angle check. This will point the velocity in the right direction,
				if(rb.velocity.magnitude>accelerationSpeed&&((altAngle<-20&&altAngle>-160)||(altAngle>20&&altAngle<160)))
				{
					//Debug.Log(rb.velocity.magnitude);
					rb.velocity = Quaternion.Euler(yDir*-altAngle)*rb.velocity;
					//Debug.Log(rb.velocity.magnitude);
				}
				else
				{*/
					rb.AddForce(halfSpeed*GetAlternate()*dy);
				//}
				Debug.Log("Velocity: "+rb.velocity+"; Speed: "+rb.velocity.magnitude +"; Alternate Velocity: "+GetAlternate()+"; Velocity Angle: " + altAngle + ";");
				rb.AddRelativeForce(halfSpeed*Vector3.forward*dy);
			
			}
		}
	}
	public Vector3 GetAlternate()
	{
		altAngle = Vector3.SignedAngle(zDir,rb.velocity,yDir);
		if(rb.velocity.magnitude<accelerationSpeed)
		{
			return zDir;
		}
		return Quaternion.Euler(yDir*(-altAngle)*2)*rb.velocity;
	}
	void OnDrawGizmos()
	{
		rb = gameObject.GetComponent<Rigidbody>();
		Gizmos.color = Color.red;
		Gizmos.DrawRay(this.transform.position, xDir);//*accelerationSpeed
		Gizmos.color = Color.green;
		Gizmos.DrawRay(this.transform.position, yDir);//*accelerationSpeed
		Gizmos.color = Color.blue;
		Gizmos.DrawRay(this.transform.position, zDir);//*accelerationSpeed
		Gizmos.color = Color.yellow;
		Gizmos.DrawRay(this.transform.position, rb.velocity);
		Gizmos.color = Color.cyan;
		Gizmos.DrawRay(this.transform.position, GetAlternate());
		Gizmos.color = Color.white;
		//Gizmos.DrawRay(this.transform.position, accelerationSpeed*zDir*dy);
		Gizmos.color = Color.black;
		//Gizmos.DrawRay(this.transform.position, halfSpeed*altVel);
		
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

	public Vector3[] ReadOnlyXYZDir()
	{
		Vector3[] XYZ = new Vector3[3];
		XYZ[0] = xDir;
		XYZ[1] = yDir;
		XYZ[2] = zDir;
		return XYZ;
	}
	public float[] readOnlyXY()
	{
		float[] dxy = new float[2];
		if(onGround)
		{
			dxy[0] = dx;
			dxy[1] = dy;
		}
		else
		{
			dxy[0] = 0;
			dxy[1] = 0;
		}
		return dxy;
	}
	public void deactivate()
	{
		gameOn = false;
	}
}
