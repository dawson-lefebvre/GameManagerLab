using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] string sceneName;
    PlayerController player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player = FindObjectOfType<PlayerController>();
            player.StartTransition();
            loading = true;
            
        }
    }

    bool loading = false;
    private void Update()
    {
        if (loading)
        {
            if (!player.isTransitioning)
            {
                SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
                loading = false;
            }
        }
    }
}
