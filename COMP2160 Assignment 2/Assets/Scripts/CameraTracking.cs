using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
 
 public CarMovement target; 
 private float yLock;
 public float cameraDistance = 4;
 private Vector3 direction;
 private Vector3 destination;
 private Vector3 predir;
 public float decay = 0.1f;
 private float lerpReadOnlyY = 0;
 private float lerpReadOnlyX = 0;



// Start is called before the first frame update
    void Start()
    {
        yLock = target.transform.position.y;
    }

    // Update is called once per frame
 void Update() 
 { 
	//lerpReadOnlyY = Mathf.Lerp(target.readOnlyY(),lerpReadOnlyY,decay);
	
	direction = (4+target.readOnlyY())*(-target.ReadOnlyDir().normalized);
	if(target.readOnlyY()!=0)
	{
		direction = Quaternion.Euler(Vector3.up*-30*target.readOnlyX())*direction;
	}
	Debug.DrawRay(target.transform.position, direction, Color.blue);
	Debug.DrawRay(target.transform.position, predir, Color.red);
	destination = target.transform.position + direction;//new Vector3(direction.x, 0, direction.z);
	Debug.Log("Direction: " + direction + "; Destination: " + destination + "; DY: "+target.readOnlyY()+"; DX: "+ target.readOnlyX()+";");
	transform.position = destination;
	//transform.position = Vector3.Lerp(transform.position, destination, decay);
	//predir = Vector3.Lerp(transform.position, direction, decay);
	transform.forward = -direction;
	//transform.rotation = new Quaternion(0,target.transform.rotation.y,0,target.transform.rotation.w);
	
	
	
	//Debug.Log("Camera Distance: " + destination.magnitude);
	//Debug.Log(target.transform.rotation);
	//transform.right = target.position - transform.position;
	//transform.rotation = 
	//transform.Translate(new Vector3(0,yLock-transform.position.y, 0));
 } 
}
