using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Button play;

    void Start()
    {
        play.onClick.AddListener(PlayGame);
    }

    void PlayGame()
    {

        SceneManager.LoadScene("Game");
        Debug.Log("Button clicked");
    }
}
