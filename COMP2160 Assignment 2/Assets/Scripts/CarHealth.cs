using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHealth : MonoBehaviour
{
    public float Health = 100;
	public float damageThreshold = 50;
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void OnCollisionEnter(Collision collision)
    {
            Debug.Log(collision.impulse.magnitude);
			if(collision.impulse.magnitude<damageThreshold)
			{
			}
			else
			{
			}
			
    }

}
