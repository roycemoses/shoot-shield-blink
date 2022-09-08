using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2_hold_shield_toward_player1 : MonoBehaviour
{  
    public Rigidbody2D rb;
    Vector2 mousePos;
    Vector2 mouseDirection;
    public static float angle;
    public Camera cam;
    public Vector2 mouseCursorPosition;
    public bool shielding;

    void Start()
    {
        transform.position = transform.parent.position;
    }

    // Update is called once per frame
    void Update()
    {
        // mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        // mouseDirection = mousePos - rb.position;
        // angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;
        // if (Input.GetButtonDown("Fire1"))
        //     Debug.Log("angle: " + angle);

        transform.position = transform.parent.position;

        if (!shielding) // If not shielding, follow player cursor. If shielding, disable this part to maintain the shield's initial rotation
        {
            mouseCursorPosition = GameObject.Find("Player1").transform.position;    
            mouseDirection = mouseCursorPosition - rb.position;
            angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;
            // Debug.Log("Angle: " + angle);
            rb.rotation = angle;
        }
    }
}