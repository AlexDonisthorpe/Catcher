using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private float minRotation = 1f;
    [SerializeField] private float maxRotation = 5f;
    
    private Vector2 _destination;
    private Vector2 _screenBottom;
    private float _rotationVelocity;

    void Start()
    {
        _rotationVelocity = Random.Range(-maxRotation, maxRotation);
        _screenBottom = new Vector2(transform.position.x, Camera.main.ScreenToWorldPoint(Vector2.zero).y);
        SetDestination(_screenBottom);
    }

    private void SetDestination(Vector2 target)
    {
        _destination = target;
    }

    void FixedUpdate()
    {
        float step = Time.deltaTime * speed;
        transform.position = Vector2.MoveTowards(transform.position, _destination, step);
        transform.Rotate(new Vector3(0, 0, _rotationVelocity));
    }

    public void StopMoving()
    {
        SetDestination(transform.position);
    }

    public void Bounce()
    {
        float xPosition = transform.position.x;
        float yPosition = transform.position.y;
        
        float xBounce = Random.Range((float)(xPosition - 2), (float)(xPosition + 2));
        float yBounce = Random.Range((float)(yPosition + 2), (float)(yPosition + 4));
        
        Vector2 newDest = new Vector2(xBounce, yBounce);
        
        SetDestination(newDest);
        SetRotation(xBounce);
    }

    private void SetRotation(float xBounce)
    {
        if (xBounce <= 0)
        {
            _rotationVelocity = Random.Range(minRotation, maxRotation);
        }
        else
        {
            _rotationVelocity = Random.Range(-minRotation, -maxRotation);
        }
    }
}
