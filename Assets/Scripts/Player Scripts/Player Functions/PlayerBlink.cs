using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlink : MonoBehaviour
{
    public Animator animator;

    public float blinkRate;
    public float blinkDistance;
    float nextAttackTime = 0f;
    float blinkAlign = 0.5f; // blink alignment to prevent tp'ing into walls)
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown("space"))
            {
                Vector3 originalPosition = transform.position;
                Vector3 mouseCursorPosition = new Vector3(CrosshairCursor.mouseCursorPosition.x, CrosshairCursor.mouseCursorPosition.y, 0f);
                Vector3 direction = (mouseCursorPosition  - originalPosition).normalized;
                Vector3 blinkToPosition = originalPosition + direction * blinkDistance;
                
                // Check if distance of originalPosition to mousePosition is less than distance of blinkDistance
                if ((mouseCursorPosition - originalPosition).magnitude < blinkDistance)
                    blinkToPosition = mouseCursorPosition - direction * 0.0001f; // extremely offset (to avoid bug: points RIGHT after a blink)
                    

                // Check if blinkToPosition is out of bounds
                if (blinkToPosition.x < Bounds.Xmin)
                    blinkToPosition = new Vector3(Bounds.Xmin + blinkAlign, blinkToPosition.y, 0);
                else if (blinkToPosition.x > Bounds.Xmax)
                    blinkToPosition = new Vector3(Bounds.Xmax - blinkAlign, blinkToPosition.y, 0);
                
                if (blinkToPosition.y < Bounds.Ymin)
                    blinkToPosition = new Vector3(blinkToPosition.x, Bounds.Ymin + blinkAlign, 0);
                else if (blinkToPosition.y > Bounds.Ymax)
                    blinkToPosition = new Vector3(blinkToPosition.x, Bounds.Ymax - blinkAlign, 0);

                transform.position = blinkToPosition;
                nextAttackTime = Time.time + 1f / blinkRate;
            }
        }
    }
}
