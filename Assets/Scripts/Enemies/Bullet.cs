using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] float _existTime;
    private Rigidbody2D rb;
    float _entryTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _entryTime = Time.time;
    }

    void Update()
    {
        rb.velocity = new Vector2(_force * -1, rb.velocity.y);
        if (Time.time - _entryTime >= _existTime)
            gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
