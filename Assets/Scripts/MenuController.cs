using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Button play;
    public Button quit;

    void Start()
    {
        play.onClick.AddListener(PlayGame);
        quit.onClick.AddListener(QuitGame);
    }

    void PlayGame()
    {

        SceneManager.LoadScene("Game");
    }

    void QuitGame()
    {
        Debug.Log("Game Quitted");
        Application.Quit();
    }
}
