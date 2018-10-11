using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject FailPanel;

    public void FinishGame()
    {
        FailPanel.SetActive(false);
    }

    public void ReStartGame()
    {
        SceneManager.LoadScene("MainScene");
        AllStaticVariable.ResetVariable();    
    }
}
