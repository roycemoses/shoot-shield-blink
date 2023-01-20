using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    GameObject player1;
    GameObject player2;
    GameObject player1Stocks;
    GameObject player2Stocks;
    GameObject roundStartBarriers;
    public float countdownSeconds;

    void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player1Stocks = GameObject.Find("Player1Stocks");
        player2Stocks = GameObject.Find("Player2Stocks");
        roundStartBarriers = GameObject.Find("RoundStartBarriers");
        DisableControls();
    }

    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            GameStart();
        }
    }

    public void GameStart()
    {
        player1Stocks.GetComponent<Player1Stocks>().resetStocks();
        player2Stocks.GetComponent<Player2Stocks>().resetStocks();
        RoundStart();
    }

    public void GameOver()
    {
        DisableControls();
    }

    public void RoundStart()
    {
        roundStartBarriers.SetActive(true);
        player1.GetComponent<Transform>().position = new Vector3(-8, -4, 0);
        player2.GetComponent<Transform>().position = new Vector3(8, 4, 0);
        player1.GetComponent<PlayerStats>().SetHealth(1f);
        player2.GetComponent<PlayerStats>().SetHealth(1f);
        StartCoroutine(Countdown());
    }

    public IEnumerator Countdown()
    {
        yield return new WaitForSeconds(countdownSeconds);
        roundStartBarriers.SetActive(false);
        EnableControls();
    }

    public void EnableControls()
    {
        player1.GetComponent<PlayerMovement>().enabled = true;
        player1.GetComponent<PlayerAttack>().enabled = true;
        player1.GetComponent<PlayerShield>().enabled = true;
        player1.GetComponent<PlayerBlink>().enabled = true;
    }

    public void DisableControls()
    {
        player1.GetComponent<PlayerMovement>().enabled = false;
        player1.GetComponent<PlayerAttack>().enabled = false;
        player1.GetComponent<PlayerShield>().enabled = false;
        player1.GetComponent<PlayerBlink>().enabled = false;
    }
}
