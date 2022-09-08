using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public Animator animator;

    public float shieldDurationSeconds;
    public float shieldCooldownSeconds;
    public bool isShielding;
    public bool onCooldown;

    public GameObject firePoint;
    public GameObject shield;
    
    void Start()
    {
        firePoint = transform.Find("Firepoint").gameObject;
        shield = firePoint.transform.Find("Shield").gameObject;
        shield.transform.position = transform.position;
        shield.SetActive(false);
        isShielding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShielding & !onCooldown)
            if (Input.GetButtonDown("Fire2"))
                StartCoroutine(Shield());
    }
    
    public IEnumerator Shield()
    {
        shield.SetActive(true);
        isShielding = true;
        firePoint.GetComponent<SpriteRenderer>().enabled = false;
        firePoint.GetComponent<PlayerFirepointCam>().shielding = true;

        yield return new WaitForSeconds(shieldDurationSeconds);
            
        shield.SetActive(false);
        isShielding = false;
        firePoint.GetComponent<SpriteRenderer>().enabled = true;
        firePoint.GetComponent<PlayerFirepointCam>().shielding = false;

        onCooldown = true;

        yield return new WaitForSeconds(shieldCooldownSeconds);

        onCooldown = false;    
    }
}