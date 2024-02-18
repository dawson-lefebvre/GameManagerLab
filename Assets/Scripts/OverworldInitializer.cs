using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    bool playerLoaded = false;


    void Awake()
    {
        Scene[] scenesOpen = SceneManager.GetAllScenes(); 

        foreach (Scene scene in scenesOpen)
        {
            if (scene.name == "Player")
            {
                playerLoaded = true;
            }
        }

        if (!playerLoaded)
        {
            SceneManager.LoadScene("Player", LoadSceneMode.Additive);
        }

    }
    [SerializeField] Transform westSpawn, northSpawn, eastSpawn, southSpawn;
    private void Start()
    {
        if (!playerLoaded)
        {
            FindObjectOfType<PlayerController>().transform.position = Vector3.zero;
        }
        else
        {
            //Find which town the player came from, TP to exit location and end transition
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene s = SceneManager.GetSceneAt(i);
                if (s != null)
                {
                    if (s.name == "WestTown")
                    {
                        PlayerController player = FindObjectOfType<PlayerController>();
                        player.transform.position = westSpawn.position;
                        player.EndTransition();
                        SceneManager.UnloadSceneAsync("WestTown");
                    }
                    else if (s.name == "EastTown")
                    {
                        PlayerController player = FindObjectOfType<PlayerController>();
                        player.transform.position = eastSpawn.position;
                        player.EndTransition();
                        SceneManager.UnloadSceneAsync("EastTown");
                    }
                    else if (s.name == "SouthTown")
                    {
                        PlayerController player = FindObjectOfType<PlayerController>();
                        player.transform.position = southSpawn.position;
                        player.EndTransition();
                        SceneManager.UnloadSceneAsync("SouthTown");
                    }
                    else if (s.name == "NorthTown")
                    {
                        PlayerController player = FindObjectOfType<PlayerController>();
                        player.transform.position = northSpawn.position;
                        player.EndTransition();
                        SceneManager.UnloadSceneAsync("NorthTown");
                    }
                }
            }
        }
    }
}
