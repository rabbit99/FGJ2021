using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void RetrunToDialogue()
    {
        SceneManager.LoadScene("Talk");
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("EvilNum", 0);
        PlayerPrefs.SetInt("Converation", 0);
        PlayerPrefs.SetString("CurrectStory", "");
        SceneManager.LoadScene("Talk");
    }

    public void EndGame()
    {
        UnityEngine.Application.Quit();
    }

    public void RetrunToStart()
    {
        SceneManager.LoadScene("Start");
    }
}
