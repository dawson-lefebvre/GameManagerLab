using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TownManager : MonoBehaviour
{
    [SerializeField] Transform playerSpawn;
    [SerializeField] GameObject treasure;
    public string townName;
    public TownData townData;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PlayerController>().transform.position = playerSpawn.position;
        FindObjectOfType<PlayerController>().EndTransition();
        SceneManager.UnloadSceneAsync("Overworld");

        //Get Data
        townData = SaveLoadManager.LoadTownData($"SaveData/TownData/{townName}.xml");

        if(townData == null)
        {
            townData = new TownData();
        }

        if (townData.hasCollectedTreasure)
        {
            treasure.SetActive(false);
        }

        if (townData.spawnMonsters)
        {
            //Spawn Monsters
            List<GameObject> enemies = FindObjectOfType<EnemySpawner>().SpawnEnemies();
            foreach (GameObject enemy in enemies)
            {
                SceneManager.MoveGameObjectToScene(enemy, SceneManager.GetSceneByName(townName));
            }
            townData.spawnMonsters = false;
            SaveLoadManager.SaveTownData(townData, $"SaveData/TownData/{townName}.xml");
        }
    }

    public void CollectTreasure()
    {
        townData.hasCollectedTreasure = true;
        SaveLoadManager.SaveTownData(townData, $"SaveData/TownData/{townName}.xml");
    }
}
