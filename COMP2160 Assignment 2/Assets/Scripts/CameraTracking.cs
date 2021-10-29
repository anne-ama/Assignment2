using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
 
 public CarMovement target; 
 private float yLock;


// Start is called before the first frame update
    void Start()
    {
        yLock = target.transform.position.y;
    }

    // Update is called once per frame
 void Update() 
 { 
	transform.position = target.transform.position;//new Vector3(target.transform.position.x, yLock, target.transform.position.z); //target.ReadOnlyDir()
	Debug.Log(target.transform.rotation);
	//transform.rotation = new Quaternion(0,target.transform.rotation.y,0,0);
	//transform.rotation = 
	//transform.Translate(new Vector3(0,yLock-transform.position.y, 0));
 } 
}
