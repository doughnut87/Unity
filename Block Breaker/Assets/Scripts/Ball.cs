using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool hasStarted;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        // slow it down!
        if (Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.y) > 10f)
        {
            var newSpeed = new Vector2(Mathf.Clamp(this.GetComponent<Rigidbody2D>().velocity.x, -10f, 10f),
                                                   Mathf.Clamp(this.GetComponent<Rigidbody2D>().velocity.y, -10f, 10f));
            this.GetComponent<Rigidbody2D>().velocity = newSpeed;
            Debug.LogWarning("too fast!");
        }
        
        if (hasStarted)
			return;
			
		if (Input.GetMouseButtonDown(0))
		{
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-.2f,.2f), 10f);
			hasStarted = true;
			var sbSpinner = GameObject.FindObjectOfType<SBSpinner>();
			sbSpinner.SetVisible(true);
			paddle.playSonicBoom();
			paddle.setStarted();
		}
			
		// lock position to ball
		transform.position = paddleToBallVector + paddle.transform.position;
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
	    // add some randomness but not when its going too fast.
		if (Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.x) +  Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.y) < 10f)
		{
			var reboundRandomization = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x < 0 ? Random.Range(-0.2f, 0f) : Random.Range(0f, 0.2f),
		                                           this.GetComponent<Rigidbody2D>().velocity.y < 0 ? Random.Range (-0.2f, 0f) : Random.Range(0f, 0.2f)); 
			this.GetComponent<Rigidbody2D>().velocity += reboundRandomization;
		}
		
		if (hasStarted)
			GetComponent<AudioSource>().Play();
	}
}
