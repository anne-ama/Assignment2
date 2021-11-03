using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
 
 public CarMovement target; 
 public GameObject car;
 private float yLock;
 public float cameraDistance = 1;
 private Vector3 direction;
 private Vector3 destination;
 private Vector3 predir;
 public float threshold = 0.1f;
 public float decay = 0.1f;
 private float preY = 0;
 private float preX = 0;
 private bool lerp = false;
 private float[] preXY = new float[2];



// Start is called before the first frame update
    void Start()
    {
        yLock = target.transform.position.y;
    }

    // Update is called once per frame
	void Update() 
	{ 
		for(int i = 0; i<2; i++)
		{
			if(Mathf.Abs(target.readOnlyXY()[i]-preXY[i])>threshold)
			{
				lerp=true;
			}
			preXY[i]=target.readOnlyXY()[i];
		}
		direction = (4+target.readOnlyY())*(-target.ReadOnlyDir().normalized);
		if(target.readOnlyY()!=0)
		{
			direction = Quaternion.Euler(Vector3.up*-30*target.readOnlyX())*direction;
		}
		Debug.DrawRay(target.transform.position, direction, Color.cyan);
		if(lerp)
		{
			predir = Vector3.Lerp(predir, direction, decay);
			if((direction-predir).magnitude<threshold)
			{
				lerp = false;
			}
		}
		else
		{
			predir=direction;
		}
		destination = target.transform.position + predir;
		transform.position = destination;
		transform.forward = -predir;
	//new Vector3(direction.x, 0, direction.z);
	/*Vector3 carViewPort = Camera.main.WorldToViewportPoint (target.transform.position);
	Vector3 worldMiddleP = Camera.main.ViewportToWorldPoint(carViewPort + cameraDistance * Vector3.right * Input.GetAxis("Horizontal"));
	transform.position = Vector3.Lerp(transform.position, worldMiddleP, Time.deltaTime * decay);
	//lerpReadOnlyY = Mathf.Lerp(target.readOnlyY(),lerpReadOnlyY,decay);
	//direction = car.forward;*/

	
	//Debug.Log("Direction: " + direction + "; Destination: " + destination + "; DY: "+target.readOnlyY()+"; DX: "+ target.readOnlyX()+";");
	//transform.position = destination;
	//predir = Vector3.Lerp(transform.position, direction, decay);
	//transform.rotation = new Quaternion(0,target.transform.rotation.y,0,target.transform.rotation.w);
	
	
	
	//Debug.Log("Camera Distance: " + destination.magnitude);
	//Debug.Log(target.transform.rotation);
	//transform.right = target.position - transform.position;
	//transform.rotation = 
	//transform.Translate(new Vector3(0,yLock-transform.position.y, 0));
				//Debug.DrawRay(target.transform.position, predir, Color.red);
			//transform.position = Vector3.Lerp(transform.position, destination, decay);

 } 

void LateUpdate()
{

}
}