using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Stocks : MonoBehaviour
{
    public GameObject[] stocksArr;
    public Sprite emptyStock;
    public int numStocks = 3;
    public int currentStock;

    void Start()
    {
        stocksArr = new GameObject[numStocks];
        for (int i = 0; i < numStocks; i++)
            stocksArr[i] = this.gameObject.transform.GetChild(i).gameObject;
        emptyStock = GameObject.Find("EmptyStock").GetComponent<SpriteRenderer>().sprite;
        currentStock = numStocks - 1;
    }

    public void decrementStock()
    {
        if (currentStock >= 0)
        {
            stocksArr[currentStock].GetComponent<SpriteRenderer>().sprite = emptyStock;
            currentStock--;
        }
    } 
}
