﻿using UnityEngine;
using System.Collections;

public class BorderScript : MonoBehaviour
{
    public float offset;

    void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 newPosition = other.gameObject.transform.position;
        newPosition.x = (newPosition.x * -1) + offset;
        other.gameObject.transform.position = newPosition;
    }
}
