using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()//the PlayGame function tied to the play game button
    {
        SceneManager.LoadScene("Level-1");//loads the Level-1 game scene
    }

    public void quitGame()//the quitGame function tied to the quit game button
    {
        Application.Quit();// terminates the game
        Debug.Log("Quit");//
    }
}
