using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
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

    public void QuitGame()//the quitGame function tied to the quit game button
    {
        Application.Quit();// terminates the game
        Debug.Log("Quit");//
    }

    public void BackToMerchant() //NS
    {
        SceneManager.LoadScene("Merchant_Room");
    }

    public void PreviousScene() //NS
    {
        switch (counter)
        {
            case 1:
                SceneManager.LoadScene("Level-1-4");
                //back to level 1-4
                break;

            case 2:
                //back to level 2-7
                break;

            case 3:
                //back to level 3-4
                break;

            case 4:
                //back to level 3-7
                break;

            case 5:
                //back to level 4-2
                break;
        }
    }

    public void LoadNextLevel()
    {
       StartCoroutine (LoadLevel(SceneManager.GetActiveScene().buildIndex + 1)); 
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("StartFade");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
