using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{

    public void StartButtonPress()
    {
        Debug.Log("Evento 1!");
        SceneManager.LoadScene("Levels", LoadSceneMode.Single);
    }


    public void LevelButtonPress()
    {
        Debug.Log("Evento 2!");
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}

