using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthUI, treasureUI;

    PlayerData playerData;

    private void Start()
    {
        playerData = SaveLoadManager.LoadPlayerData("SaveData/PlayerData.xml");
        if(playerData == null)
        {
            playerData = new PlayerData();
            playerData.health = 5;
        }
        healthUI.text = playerData.health.ToString();
        treasureUI.text = playerData.treasure.ToString();
    }
    public void UpdateTreasureValue(int value)
    {
        playerData.treasure += value;
        treasureUI.text = playerData.treasure.ToString();
    }

    public void DamagePlayer(int value)
    {
        playerData.health -= value;
        healthUI.text = playerData.health.ToString();
    }

    public void SetHealth(int value)
    {
        playerData.health = value;
        healthUI.text = playerData.health.ToString();
    }


    public void SavePlayer()
    {
        SaveLoadManager.SavePlayerData(playerData, $"SaveData/PlayerData.xml");
    }
}
