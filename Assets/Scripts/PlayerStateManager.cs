using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    Rigidbody2D _rb;
    float _dirX;
    float _dirY;
    [SerializeField] float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        _dirX = Input.GetAxisRaw("Horizontal");
        _dirY = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_dirX * _speed, _rb.velocity.y);
    }
}
