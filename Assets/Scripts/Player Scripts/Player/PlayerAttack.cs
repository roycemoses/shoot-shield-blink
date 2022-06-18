using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    public float attackRate = 10f;
    float nextAttackTime = 0f;

    public float angle;

    public GameObject playerFirepoint;
    
    void Start()
    {
        playerFirepoint = GameObject.Find("Firepoint");
    }

    // Update is called once per frame
    void Update()
    {
        angle = PlayerShootCam.angle;

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                playerFirepoint.GetComponent<PlayerShoot>().Shoot();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
}
