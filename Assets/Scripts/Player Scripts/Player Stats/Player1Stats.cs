using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Stats : MonoBehaviour
{
    public float health = 1f;
    public int stocks = 3;
    public GameObject Player1HealthBar;
    void Start()
    {
        Player1HealthBar = GameObject.Find("Player1HealthBar");
    }
}
