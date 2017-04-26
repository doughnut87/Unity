 using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public AudioClip[] audioSounds;
	private bool isStarted;
	private Ball m_ball;
	public bool isAutoPlay = false;

	// Use this for initialization
	void Start () {
		m_ball = FindObjectOfType<Ball>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isAutoPlay && isStarted)
		{
			AutoPlay ();
        } 
		else
		    MoveWithMouse();

	
	}
	
	void AutoPlay()
	{
		var paddlePosition = new Vector3(Mathf.Clamp(m_ball.transform.position.x, 1.2f, 14.8f ),this.transform.position.y, this.transform.position.z);
		this.transform.position = paddlePosition;
	
	}
	
	void MoveWithMouse()
	{
		var mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		var paddlePosition = new Vector3(Mathf.Clamp(mousePosInBlocks, 1.2f, 14.8f ), this.transform.position.y, this.transform.position.z);
		this.transform.position = paddlePosition;
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (!isStarted)
			return;
		if (audioSounds.Length > 0)
			AudioSource.PlayClipAtPoint(audioSounds[Random.Range(0, audioSounds.Length)], Camera.main.transform.position);
	}

	public void playSonicBoom ()
	{
		if (audioSounds.Length > 0)
			AudioSource.PlayClipAtPoint(audioSounds[0], Camera.main.transform.position);
	}

	public void setStarted ()
	{
		isStarted = true;
	}
}
