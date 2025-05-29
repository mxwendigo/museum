using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
   
   public void PlayGame()
    {
        SceneManager.LoadSceneAsync("QuizScene1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
