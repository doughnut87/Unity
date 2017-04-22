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
			this.rigidbody2D.velocity = new Vector2(2f, 10f);
			hasStarted = true;
			var sbSpinner = GameObject.FindObjectOfType<SBSpinner>();
			sbSpinner.isVisible = true;
			paddle.playSonicBoom();
			paddle.setStarted();
		}
			
		// lock position to ball
		transform.position = paddleToBallVector + paddle.transform.position;
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (hasStarted)
			audio.Play();
	}
}
