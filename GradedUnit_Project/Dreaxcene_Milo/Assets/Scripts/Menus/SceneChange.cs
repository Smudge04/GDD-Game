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

    public void Start()
    {
        instance = this;    
    }

    public void PlayGame()//the PlayGame function tied to the play game button
    {
        SceneManager.LoadScene("Level-1");
    }

    public void QuitGame()//the quitGame function tied to the quit game button
    {
        Application.Quit();// terminates the game
        Debug.Log("Quit");//
    }

    public void Test()
    {
        SceneManager.LoadScene("Level-1");
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
