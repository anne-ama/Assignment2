using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
 
 public CarMovement target; 
 //public GameObject car;
 private float yLock;
 public float cameraDistance = 1;
 private Vector3 direction;
 private Vector3 destination;
 private Vector3 predir;
 public float threshold = 0.1f;
 public float decay = 0.1f;
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
		direction = (4+target.readOnlyXY()[1])*(-target.ReadOnlyDir().normalized);
		if(target.readOnlyXY()[1]!=0)
		{
			direction = Quaternion.Euler(Vector3.up*-30*target.readOnlyXY()[0])*direction;
		}
		//Debug.DrawRay(target.transform.position, direction, Color.cyan);
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
	} 

	void OnDrawGizmos()
	{
		Gizmos.color = Color.magenta;
		Gizmos.DrawRay(target.transform.position, direction);
	}
}