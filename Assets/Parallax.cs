using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [System.Serializable]
    public class BackgroundObject
    {
        public GameObject _gameObject;
        public float speed;

        private Material _material;
        private Vector2 offset;

        public void SetMaterial()
        {
            _material = _gameObject.GetComponent<Renderer>().material;
        }

        public void SetOffset()
        {
            offset = new Vector2(0f, speed);
        }

        public void UpdateTexture()
        {
            _material.mainTextureOffset += offset * Time.deltaTime;
        }
    }

    [SerializeField] private BackgroundObject[] _backgroundObjects;
    void Awake()
    {
        foreach (BackgroundObject _object in _backgroundObjects)
        {
            _object.SetOffset();
            _object.SetMaterial();
        }
    }

    void Update()
    {
        foreach (BackgroundObject _object in _backgroundObjects)
        {
            _object.UpdateTexture();
        }
    }
}
