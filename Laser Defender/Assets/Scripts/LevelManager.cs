using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

    public static int m_guess;

    public void LoadLevel(string name)
    {
        Debug.Log("Level load Requested for: " + name);
        Application.LoadLevel(name);
    }

    public void RequestQuit(string name)
    {
        Debug.Log("Quit Requested for: " + name);
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

}
 