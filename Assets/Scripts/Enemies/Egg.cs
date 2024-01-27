using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] float _existTime;
    private Rigidbody2D rb;
    float _entryTime;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _entryTime = Time.time;
        rb.AddForce(Vector2.left * _force, ForceMode2D.Impulse);
        rb.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
    }

    void Update()
    {
        if (Time.time - _entryTime >= _existTime)
            gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ObjectPooler.Instant.GetPoolObject("EggPiece", transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            ObjectPooler.Instant.GetPoolObject("EggPiece", transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }


}
