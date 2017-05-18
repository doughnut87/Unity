using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float m_shipSpeed = 8f;
	public float m_shipPadding = 1f;
	float xMin;
	float xMax;
	
	// Use this for initialization
	void Start () 
	{
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
	
		xMin = leftMost.x + m_shipPadding;
		xMax = rightMost.x - m_shipPadding;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			//this.transform.position += new Vector3(- m_shipSpeed * Time.deltaTime, 0, 0);
			this.transform.position += Vector3.left * m_shipSpeed * Time.deltaTime;
		}
		
		if(Input.GetKey(KeyCode.RightArrow))
		{
			//this.transform.position += new Vector3(m_shipSpeed * Time.deltaTime, 0, 0);
			this.transform.position += Vector3.right * m_shipSpeed * Time.deltaTime;
		}
		
		// Restrict to Gamespace
		float newX = Mathf.Clamp(transform.position.x, xMin, xMax);
		transform.position = new Vector3(newX,transform.position.y, transform.position.y);
	}
}
