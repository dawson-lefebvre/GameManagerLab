using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SaveLoadManager.DeleteExistingData();
        SceneManager.LoadScene("Overworld");
    }

    public void Resume()
    {
        SceneManager.LoadScene("Overworld");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
