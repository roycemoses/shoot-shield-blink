using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Stocks : MonoBehaviour
{
    public GameObject[] stocksArr;
    public GameObject gameController;
    public Sprite emptyStock;
    public Sprite player1Stock;
    public int numStocks;
    public int currentStock;

    void Start()
    {
        stocksArr = new GameObject[numStocks];
        for (int i = 0; i < numStocks; i++)
            stocksArr[i] = this.gameObject.transform.GetChild(i).gameObject;
        gameController = GameObject.Find("GameController");
        emptyStock = GameObject.Find("EmptyStock").GetComponent<SpriteRenderer>().sprite;
        player1Stock = GameObject.Find("Player1Stock").GetComponent<SpriteRenderer>().sprite;
        numStocks = 3;
        currentStock = numStocks - 1;
    }

    public void decrementStock()
    {
        if (currentStock >= 0)
        {
            stocksArr[currentStock].GetComponent<SpriteRenderer>().sprite = emptyStock;
            currentStock--;
            if (currentStock < 0)
                gameController.GetComponent<GameController>().GameOver();
            else
                gameController.GetComponent<GameController>().RoundStart();
        }
    }

    public void resetStocks()
    {
        for (int i = 0; i < numStocks; i++)
            stocksArr[i].GetComponent<SpriteRenderer>().sprite = player1Stock;
        currentStock = numStocks - 1;
    }
}
