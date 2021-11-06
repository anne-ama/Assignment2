using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround : MonoBehaviour
{
	public LayerMask groundLayer;
	private BoxCollider bc;
	private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        bc = gameObject.GetComponent<BoxCollider>();
		rb = gameObject.GetComponent<Rigidbody>();
		bc.isTrigger = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void OnTriggerStay(Collider other)// This needs to be edited to account for layers
	{
		GameObject collider = other.gameObject;
		Debug.Log("Readings");
		
		if(groundLayer.Contains(collider))//Layers.Instance.player.Contains(collider)
		{
			Debug.Log("Movement is true");
		}
		
		//GameObject collider = other.gameObject;
		//if(Layers.pl.Terr
		//if(other.name=="Terrain")
		//{
		//	isGrounded();
		//	Debug.Log("True");
		//}
	}

}
