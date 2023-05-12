using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public static SceneChange instance;

    private void Start()
    {
        instance = this;    
    }

    public void PlayGame()//the PlayGame function tied to the play game button
    {
        SceneManager.LoadScene("Level-1");//loads the Level-1 game scene
    }

    public void QuitGame()//the quitGame function tied to the quit game button
    {
        Application.Quit();// terminates the game
        Debug.Log("Quit");//
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
