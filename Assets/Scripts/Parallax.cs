using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float spriteLenght;
    private float startPosition;

    [SerializeField] private GameObject mainCamera;
    [SerializeField] private float parallaxFactor;

    private void Update()
    {
        Move();
    }
    private void Start()
    {
        GetStartPosition();
        GetSpriteLengh();

    }
    void GetStartPosition()
    {
        startPosition = transform.position.x;
    }
    void GetSpriteLengh()
    {
        spriteLenght = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
    }

    void Move()
    {
        float temp = (mainCamera.transform.position.x * (1 - parallaxFactor));
        float distance = (mainCamera.transform.position.x * parallaxFactor);
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);

        if (temp > startPosition)
            startPosition += spriteLenght;
        else if (temp < startPosition - spriteLenght)
            startPosition -= spriteLenght;
    }
}
