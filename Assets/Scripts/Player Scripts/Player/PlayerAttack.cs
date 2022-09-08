using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    public float attackRate = 10f;
    float nextAttackTime = 0f;

    public GameObject playerFirepoint;
    
    void Start()
    {
        playerFirepoint = transform.Find("Firepoint").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
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
