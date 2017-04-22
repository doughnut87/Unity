 using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public AudioClip[] audioSounds;
	private bool isStarted;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	var mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
	
		var paddlePosition = new Vector3(Mathf.Clamp(mousePosInBlocks, 1f, 15f ), this.transform.position.y, this.transform.position.z);
	
	this.transform.position = paddlePosition;
	
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (!isStarted)
			return;
		if (audioSounds.Length > 0)
			AudioSource.PlayClipAtPoint(audioSounds[Random.Range(0, audioSounds.Length)], this.transform.position);
	}

	public void playSonicBoom ()
	{
		if (audioSounds.Length > 0)
			AudioSource.PlayClipAtPoint(audioSounds[0], this.transform.position);
	}

	public void setStarted ()
	{
		isStarted = true;
	}
}
