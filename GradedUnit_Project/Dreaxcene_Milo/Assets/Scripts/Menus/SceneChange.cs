using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour //NS
{
    public static SceneChange instance;

    public Animator transition;

    public float transitionTime = 1f;

    public int counter; //NS - checks for level

    public void Start()
    {
        instance = this;    
    }

    private void FixedUpdate()
    {
        counter = VariableStatManager.instance.Counter;
    }

    public void PlayGame()//the PlayGame function tied to the play game button
    {
        LoadNextLevel();
    }

    public void HelpScreen()
    {
        SceneManager.LoadScene("HelpScreen");
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void EmptyRoom()
    {
        SceneManager.LoadScene("EmptyRoom");
    }

    public void QuitGame()//the quitGame function tied to the quit game button
    {
        Application.Quit();// terminates the game
        Debug.Log("Quit");//
    }

    public void BackToMerchant() //NS
    {
        SceneManager.LoadScene("Merchant_Room_noUPGRADE");
        ShowCanvas.instance.CanShow = true;
    }

    public void NextScene() //NS
    {
        switch (counter)
        {
            case 1:
                SceneManager.LoadScene("Level-1-5");
                break;

            case 2:
                SceneManager.LoadScene("Level-3-1");
                break;

            case 3:
                SceneManager.LoadScene("Level-3-5");
                break;

            case 4:
                SceneManager.LoadScene("Level-4-1");
                break;

            case 5:
                SceneManager.LoadScene("Level-4-3");
                break;
        }
    }

    public void GameOver()
    {
        ShowCanvas.instance.CanShow = false;
        StartCoroutine(BeginGameOver());
    }

    IEnumerator BeginGameOver()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Stand-in Game finished"); //Change to game over screen
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ShowCanvas.instance.CanShow = true;
    }
}
