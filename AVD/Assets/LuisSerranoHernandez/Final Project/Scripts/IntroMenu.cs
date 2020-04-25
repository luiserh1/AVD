using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroMenu : MonoBehaviour
{
    public void OnPlayButtonPressed()
    {
        Debug.Log("Play button pressed");
        SceneManager.LoadScene("Cinematic");
    }

    public void OnCreditsButtonPressed()
    {
        Debug.Log("Credits button pressed");
        SceneManager.LoadScene("Credits");
    }
}
