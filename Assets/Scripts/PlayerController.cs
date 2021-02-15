using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    
    private Vector2 _destination;
    private Camera _mainCamera;

    void Awake()
    {
        _mainCamera = Camera.main;
        _destination = transform.position;
    }

    void Update()
    {
        if (Input.touchSupported && Input.touchCount > 0)
        {
            Vector3 touchPos = GetWorldSpacePosition(Input.GetTouch(0).position);
            _destination = new Vector2(touchPos.x, transform.position.y);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = GetWorldSpacePosition(Input.mousePosition);
            _destination = new Vector2(mousePos.x, transform.position.y);
        }
        else
        {
            _destination = transform.position;
        }
        
        transform.position = Vector2.MoveTowards(transform.position,_destination, speed * Time.deltaTime);
    }

    private Vector3 GetWorldSpacePosition(Vector2 pointerPosition)
    {
        return _mainCamera.ScreenToWorldPoint(pointerPosition);
    }
}
