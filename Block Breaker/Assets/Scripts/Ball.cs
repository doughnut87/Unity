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
		
		if (hasStarted)
			return;
			
		if (Input.GetMouseButtonDown(0))
		{
			this.rigidbody2D.velocity = new Vector2(Random.Range(-.2f,.2f), 10f);
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
		var reboundRandomization = new Vector2(Mathf.Abs(this.rigidbody2D.velocity.x) < 5f ? this.rigidbody2D.velocity.x < 0 ? Random.Range(-0.2f, 0f) : Random.Range(0f, 0.2f) : 0f,
		                                       Mathf.Abs(this.rigidbody2D.velocity.y) < 5f ? this.rigidbody2D.velocity.y < 0 ? Random.Range (-0.2f, 0f) : Random.Range(0f, 0.2f) : 0f); 
		this.rigidbody2D.velocity += reboundRandomization;
		if (hasStarted)
			audio.Play();
	}
}
