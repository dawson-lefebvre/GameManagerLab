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
    [SerializeField] Transform westSpawn, northSpawm, eastSpawn, southSpawm;
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
                }
            }
        }
    }
}
