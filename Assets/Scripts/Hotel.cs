using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotel : MonoBehaviour
{
    [SerializeField] GameObject UI;
    public void Sleep()
    {
        FindObjectOfType<PlayerInfo>().SetHealth(5);
        FindObjectOfType<PlayerInfo>().SavePlayer();
        ResetTown("NorthTown");
        ResetTown("SouthTown");
        ResetTown("EastTown");
        ResetTown("WestTown");
    }

    void ResetTown(string townName)
    {
        TownData townData = SaveLoadManager.LoadTownData($"SaveData/TownData/{townName}.xml");
        if( townData != null )
        {
            townData.spawnMonsters = true;
            SaveLoadManager.SaveTownData(townData, $"SaveData/TownData/{townName}.xml");
        }
    }

    public void ClosePanel()
    {
        UI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if(collision.tag == "Player")
            {
                UI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "Player")
            {
                UI.SetActive(false);
            }
        }
    }
}
