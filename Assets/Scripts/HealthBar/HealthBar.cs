using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    private Transform bar;

    void Start()
    {
        bar = GameObject.Find("Bar").transform;
    }

    public void SetSize(float sizeNormalized) 
    {
        
        bar.localScale = new Vector3(sizeNormalized, 1f, 1f);
    }
    
}