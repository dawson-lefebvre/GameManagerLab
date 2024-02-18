using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject panel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(!panel.activeInHierarchy);
            if(panel.activeInHierarchy)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }

    public void Resume()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SaveAndQuit()
    {
        FindObjectOfType<PlayerInfo>().SavePlayer();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
