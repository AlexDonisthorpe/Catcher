using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    
    private Vector2 _destination;

    void Start()
    {
        SetDestination();
    }

    private void SetDestination()
    {
        _destination = new Vector2(transform.position.x, Camera.main.ScreenToWorldPoint(Vector2.zero).y);
    }

    void FixedUpdate()
    {
        float step = Time.deltaTime * speed;
        transform.position = Vector2.MoveTowards(transform.position, _destination, step);
    }
}
