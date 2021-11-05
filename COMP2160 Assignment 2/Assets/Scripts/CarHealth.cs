using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHealth : MonoBehaviour
{
    public float health = 100;
	public float damageThreshold = 10;
	public float restoration = 5;
	public float smokeThreshold = 25;
	public GameObject Smoke;
	private ParticleSystem smokeSystem;
	public GameObject Explosion;
	private ParticleSystem explosionSystem;
	private bool gameOver = false;
	private Rigidbody rb;
	private CarMovement cm;
	
	// Start is called before the first frame update
    void Start()
    {
		rb = gameObject.GetComponent<Rigidbody>();
		smokeSystem = Smoke.gameObject.GetComponent<ParticleSystem>();
		explosionSystem = Explosion.gameObject.GetComponent<ParticleSystem>();
		cm = gameObject.GetComponent<CarMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if((!gameOver)&&(health<=0))
		{
			kill();
		}
		else if(health<=smokeThreshold)
		{
			Smoke.transform.position = transform.position;
			smokeSystem.Play();
		}
    }
	void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Magnitude: " + collision.impulse.magnitude + ";");
		
		if(collision.impulse.magnitude>damageThreshold)
		{
			rb.AddForce(Vector3.up*10, ForceMode.Impulse);
			health = health + damageThreshold - collision.impulse.magnitude;
			Debug.Log("Health: " + health + ";");
			
		}
    }
	void kill()
	{
		explosionSystem.transform.position = transform.position;
		explosionSystem.Play();
			//Vector3 direction = Vec - this.transform.position;
			rb.velocity = rb.velocity + cm.ReadOnlyXYZDir()[1]*Time.fixedDeltaTime*10;
			rb.AddForce(Vector3.up*10, ForceMode.Impulse);
			rb.AddRelativeTorque(Vector3.right*10*90, ForceMode.Impulse);
			//mouseDown = false;
		cm.deactivate();
		gameOver = true;
	}

}
