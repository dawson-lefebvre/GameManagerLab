using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthUI, treasureUI;

    int treasure = 0;
    int health = 5;

    private void Start()
    {
        healthUI.text = health.ToString();
        treasureUI.text = treasure.ToString();
    }
    public void UpdateTreasureValue(int value)
    {
        treasure += value;
        treasureUI.text = treasure.ToString();
    }

    public void DamagePlayer(int value)
    {
        health -= value;
        healthUI.text = health.ToString();
        if(health <= 0)
        {
            //GameOver
        }
    }
}
