using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private int timesHit;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	private bool isBreakable;
	private LevelManager m_levelManager;
	public AudioClip[] hitSounds;
	public GameObject smoke;

	// Use this for initialization
	void Start () {
		timesHit = 0;
		isBreakable = this.tag == "Breakable";
		if (isBreakable)
		{
			breakableCount++;
		}
		m_levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionExit2D(Collision2D collision)
	{
		if (hitSounds.Length > 0)
			AudioSource.PlayClipAtPoint (hitSounds[Random.Range(0,hitSounds.Length)], Camera.main.transform.position);
			
		if (!isBreakable)
		    return;

		DoCollision();
	}
	
	void DoCollision()
	{
		timesHit++;
		print ("Brick Hit! " + timesHit + " Times");
		
		if (timesHit >= hitSprites.Length + 1)
		{
			
			print ("Brick should die");
			breakableCount--;
			m_levelManager.BrickDestroyed();
			DoSmokePuff();
			Destroy(gameObject);
		
		}
		// Damage the brick
		else
		{
			var index = timesHit - 1;
			var sprite = hitSprites[index];
			if (sprite != null)
			{
				this.GetComponent<SpriteRenderer>().sprite = sprite;
			}
		}	
	}

	void DoSmokePuff ()
	{
		GameObject smokepuff = Instantiate(smoke, this.transform.position, Quaternion.identity) as GameObject;
		smokepuff.particleSystem.startColor = this.GetComponent<SpriteRenderer>().color;
	}
}
