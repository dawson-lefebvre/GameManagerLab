using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TownInitializer : MonoBehaviour
{
    [SerializeField] Transform playerSpawn;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PlayerController>().transform.position = playerSpawn.position;
        FindObjectOfType<PlayerController>().EndTransition();
        SceneManager.UnloadSceneAsync("Overworld");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
