using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2HealthBar : MonoBehaviour
{

    private Transform player2HealthBar;

    void Start()
    {
        player2HealthBar = GameObject.Find("Player2HealthBar").transform;
    }

    public void SetSize(float sizeNormalized)
    {

        player2HealthBar.localScale = new Vector3(sizeNormalized, 1f, 1f);
    }

}