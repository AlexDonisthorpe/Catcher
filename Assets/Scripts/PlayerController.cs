using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    
    private Vector3 _destination;
    private Camera _mainCamera;

    // Start is called before the first frame update
    void Awake()
    {
        _mainCamera = Camera.main;
        _destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchSupported && Input.touchCount > 0)
        {
            Vector3 touchPos = GetWorldSpacePosition(Input.GetTouch(0).position);
            _destination = new Vector3(touchPos.x, transform.position.y, 0);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = GetWorldSpacePosition(Input.mousePosition);
            _destination = new Vector3(mousePos.x, transform.position.y, 0);
        }
        else
        {
            _destination = transform.position;
        }
        
        transform.position = Vector3.MoveTowards(transform.position,_destination, speed * Time.deltaTime);
    }

    private Vector3 GetWorldSpacePosition(Vector3 pointerPosition)
    {
        return _mainCamera.ScreenToWorldPoint(pointerPosition);
    }
}
