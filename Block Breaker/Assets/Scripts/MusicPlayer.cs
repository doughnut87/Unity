using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer m_instance;

	void Awake()
	{
		Debug.Log("Music awake" + GetInstanceID());
		if (m_instance == null)
		{
			m_instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
		else
		{
			GameObject.Destroy(gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		Debug.Log("Music start" + GetInstanceID());

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
