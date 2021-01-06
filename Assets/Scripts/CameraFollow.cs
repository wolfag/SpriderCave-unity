﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;

    public float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 position = transform.position;
            position.x = player.position.x;
            if (position.x <= minX)
            {
                position.x = minX;
            }
            if (position.x >= maxX)
            {
                position.x = maxX;
            }
            transform.position = position;
        }
    }
}
