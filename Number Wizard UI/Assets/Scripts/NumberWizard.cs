using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour { 

	int m_max;
	int m_min;
	int m_guess;
	
	int m_guessesRemaining = 10;
	
	public Text Answer;

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

		
		print (" The highest number you can pick is " + m_max);
		print (" The lowest number you can pick is " + m_min);
		
		m_max = m_max + 1; // Hack to get around max number
		m_guess = Random.Range(m_min, m_max);
		Answer.text = m_guess.ToString();
	}
	
	public void GuessLower()
	{
		m_max = m_guess;
		//print ("Down arrow pressed");
		GetNextGuess();
	
	}
	
	public void GuessHigher()
	{
		m_min = m_guess;
		//print ("Up arrow pressed");	
		GetNextGuess();	
	
	}
	
	
	void GetNextGuess()
	{
		m_guess = Random.Range(m_min, m_max);
		Answer.text = m_guess.ToString();
		m_guessesRemaining--;
		if ( m_guessesRemaining <= 0)
		{
			Application.LoadLevel("Win");
		
		}
	}
}
