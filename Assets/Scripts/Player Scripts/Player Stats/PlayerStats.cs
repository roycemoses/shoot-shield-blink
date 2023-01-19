using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float health = 1f;
    public int playerNumber = 0;
    public int stocks = 3;
    public GameObject PlayerHealthBar;
    public GameObject PlayerStocks;
    void Start()
    {
        if (playerNumber == 1)
        {
            PlayerHealthBar = GameObject.Find("Player1HealthBar");
            PlayerStocks = GameObject.Find("Player1Stocks");
        }
        else if (playerNumber == 2)
        {
            PlayerHealthBar = GameObject.Find("Player2HealthBar");
            PlayerStocks = GameObject.Find("Player2Stocks");
        }
    }

    public void SetHealth(float currentPlayerHealth)
    {
        health = currentPlayerHealth;
        if (playerNumber == 1)
            PlayerHealthBar.GetComponent<Player1HealthBar>().SetSize(currentPlayerHealth);
        else if (playerNumber == 2)
            PlayerHealthBar.GetComponent<Player2HealthBar>().SetSize(currentPlayerHealth);
    }

    public void DecrementStock()
    {
        if (playerNumber == 1)
            PlayerStocks.GetComponent<Player1Stocks>().decrementStock();
        if (playerNumber == 2)
            PlayerStocks.GetComponent<Player2Stocks>().decrementStock();
    }
}
