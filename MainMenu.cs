using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Proceeds to the Combat "scene" upon call, tied to a button press
    /// </summary>
    public void Play()
    {
        SceneManager.LoadScene("Combat");
    }

    /// <summary>
    /// Quits the application on call, tied to a button press
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
