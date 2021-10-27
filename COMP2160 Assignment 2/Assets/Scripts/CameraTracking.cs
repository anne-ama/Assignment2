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
	transform.position = target.transform.position + target.ReadOnlyDir(); 
	transform.Translate(new Vector3(0,yLock-transform.position.y, 0));
 } 
}
