using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour { 

	int m_max;
	int m_min;
	int m_guess;

	// Use this for initialization
	void Start () {
		StartGame();
	}
	
	void StartGame()
	{
		print ("Welcome to Number Wizard");
		print ("Pick a number in your head but dont tell me");
		
		m_max = 1000;
		m_min = 1;
		m_guess = Random.Range(m_min, m_max);
		
		print (" The highest number you can pick is " + m_max);
		print (" The lowest number you can pick is " + m_min);
		
		m_max = m_max + 1; // Hack to get around max number
		DoPrompt();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			m_max = m_guess;
			//print ("Down arrow pressed");
			GetNextGuess();
		}
		
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			m_min = m_guess;
			//print ("Up arrow pressed");	
			GetNextGuess();	
		}
		
		if (Input.GetKeyDown(KeyCode.Return))
		{
			print ("I won.");
			StartGame();		
		}
	
	}
	
	void DoPrompt()
	{
		print ("Is the number higher or lower than " + m_guess + "?");
		print ("up = higher, Down = lower, return = equal");
	}
	
	void GetNextGuess()
	{
		m_guess = Random.Range(m_min, m_max);
		DoPrompt();
	}
}
