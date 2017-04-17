using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public static int m_guess;
	
	public void LoadLevel(string name)
	{
		if (string.Compare(name, "start",System.StringComparison.OrdinalIgnoreCase)== 0)
		{
			m_guess = 0;
		}
	
		if (m_guess >= 5 && string.Compare(name, "game",System.StringComparison.OrdinalIgnoreCase)== 0)
		{
			Application.LoadLevel ("Win");
			return;
		}
		
		Debug.Log ("Level load Requested for: " + name);
		Application.LoadLevel(name);
	}	
	
	public void RequestQuit(string name)
	{
		Debug.Log ("Quit Requested for: " + name);
		Application.Quit();
	}
	
	public void GuessHigher()
	{
		m_guess++;
		
		Debug.Log ("Guess incremented to: " + m_guess);
		
		// make another guess but higher
		
		LoadLevel("Game");
	}
	
	public void GuessLower()
	{
		m_guess++;
		Debug.Log ("Guess incremented to: " + m_guess);
		
		// make another guess for lower
		
		LoadLevel("Game");
	}
	 
}
 