using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	public void PlayButtonPressed()
    {
        print("PLAY");
        SceneManager.LoadScene("GameScene");
    }
    public void OptionsButtonPressed()
    {
        print("OPTIONS");
    }
    public void QuitButtonPressed()
    {
        print("QUIT");
        Application.Quit();
    }
}
