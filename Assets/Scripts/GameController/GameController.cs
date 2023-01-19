using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    GameObject player1;
    GameObject player2;
    public float countdownSeconds;

    void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        GameStart();
    }

    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            RoundStart();
        }
    }

    void GameStart()
    {
        DisableControls();
    }

    void GameOver()
    {

    }

    void RoundStart()
    {
        player1.GetComponent<Transform>().position = new Vector3(-8, -4, 0);
        player2.GetComponent<Transform>().position = new Vector3(8, 4, 0);
        StartCoroutine(Countdown());
    }

    public IEnumerator Countdown()
    {
        yield return new WaitForSeconds(countdownSeconds);
        GameObject.Find("RoundStartBarriers").SetActive(false);
        EnableControls();
    }

    void EnableControls()
    {
        player1.GetComponent<PlayerMovement>().enabled = true;
        player1.GetComponent<PlayerAttack>().enabled = true;
        player1.GetComponent<PlayerShield>().enabled = true;
        player1.GetComponent<PlayerBlink>().enabled = true;
    }

    void DisableControls()
    {
        player1.GetComponent<PlayerMovement>().enabled = false;
        player1.GetComponent<PlayerAttack>().enabled = false;
        player1.GetComponent<PlayerShield>().enabled = false;
        player1.GetComponent<PlayerBlink>().enabled = false;
    }
}
