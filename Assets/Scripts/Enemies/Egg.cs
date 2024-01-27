using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] float _existTime;
    private Rigidbody2D rb;
    float _entryTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.left*_force, ForceMode2D.Impulse);
        rb.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
    }

    private void OnEnable()
    {
        _entryTime = Time.time;
    }

    void Update()
    {
        if (Time.time - _entryTime >= _existTime)
            gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {

        }
    }
}
