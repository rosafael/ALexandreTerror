using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanterna : MonoBehaviour
{
    Camera _cam;
    float speed = 6;
    bool flashState;
    public Light Luz;
    void Start()
    {
        _cam = Camera.main;
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Luz.enabled = flashState;
            flashState = !flashState;
        }

    }
}