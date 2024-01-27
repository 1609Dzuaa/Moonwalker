using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private float _force;
    private Rigidbody2D rb;
    private BoxCollider2D col;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        rb.AddForce(Vector2.left*_force, ForceMode2D.Impulse);
        rb.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player"))
        {

        }
    }
}
