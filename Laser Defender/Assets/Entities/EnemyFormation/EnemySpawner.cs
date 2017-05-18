using UnityEngine;
using System.Collections;
using System.Threading;
using System.Collections.Generic;
using System;

public class EnemySpawner : MonoBehaviour {

	public GameObject m_enemyPrefab;
	public float m_width = 10f;
	public float m_height = 5f;
	
	
	private bool m_movingRight;
	public float m_speed = 5f;
	
	private float m_xMin;
	private float m_xMax;

	// Use this for initialization
	void Start () {
	
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		
		m_xMin = leftMost.x + m_width/2;
		m_xMax = rightMost.x - m_width/2;

		foreach(Transform child in transform)
		{	
			var enemy = Instantiate(m_enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}
	
	public void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(m_width, m_height));
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.position.x < m_xMin )
		{
			m_movingRight = true;
		}
		
		if (transform.position.x > m_xMax )
		{
			m_movingRight = false;
		}
	
	    transform.position += (m_movingRight ? Vector3.right : Vector3.left) * m_speed * Time.deltaTime;
	    
	}
}
