using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1HealthBar : MonoBehaviour
{

    private Transform player1HealthBar;

    void Start()
    {
        player1HealthBar = GameObject.Find("Player1Bar").transform;
    }

    public void SetSize(float sizeNormalized) 
    {

        player1HealthBar.localScale = new Vector3(sizeNormalized, 1f, 1f);
    }
    
}