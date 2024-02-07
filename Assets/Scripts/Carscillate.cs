using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{

    Vector3 initialPosition;
    Vector3 carPosition;
    float angle = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = GameObject.Find("Car").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        angle += Time.deltaTime;
        transform.position += new Vector3
            (
            15 * Mathf.Cos(angle) * Time.deltaTime, 
            0, 
            -3 * Mathf.Sin(angle) * Time.deltaTime
            )
            ;
    }
}
