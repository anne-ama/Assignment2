using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
 
 public CarMovement target; 
 private float yLock;
 public float cameraDistance = 4;
 private Vector3 destination;


// Start is called before the first frame update
    void Start()
    {
        yLock = target.transform.position.y;
    }

    // Update is called once per frame
 void Update() 
 { 
	destination = (4+target.readOnlyY())*(-target.ReadOnlyDir());
	Debug.DrawRay(target.transform.position, destination, Color.red);
	Debug.Log("Camera Distance: " + destination.magnitude);
	transform.position = target.transform.position;//new Vector3(target.transform.position.x, yLock, target.transform.position.z); //target.ReadOnlyDir()
	Debug.Log(target.transform.rotation);
	transform.rotation = new Quaternion(0,target.transform.rotation.y,0,target.transform.rotation.w);
	//transform.rotation = 
	//transform.Translate(new Vector3(0,yLock-transform.position.y, 0));
 } 
}
