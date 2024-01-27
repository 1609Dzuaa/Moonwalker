using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct HatInfo
{
    public Vector3 Position;
    public bool ThrewFromRight;

    public HatInfo(Vector3 position, bool threwFromRight) { Position = position; ThrewFromRight = threwFromRight; }
}

public class HatController : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _timeToBackToPlayer;
    Rigidbody2D _rb;
    float _entryTime;
    bool _hasBack;
    bool _isRight;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        EventsManager.Instant.SubcribeToAnEvent(GameEnums.EEvents.HatOnBeingThrew, Enable);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        //if (EventsManager.Instance._dictEvents.ContainsKey(GameEnums.EEvents.HatOnBeingThrew))
        //EventsManager.Instant.SubcribeToAnEvent(GameEnums.EEvents.HatOnBeingThrew, Enable);
    }

    private void OnDisable()
    {
        //EventsManager.Instant.UnSubcribeToAnEvent(GameEnums.EEvents.HatOnBeingThrew, Enable);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - _entryTime >= _timeToBackToPlayer && !_hasBack)
        {
            _speed = -_speed;
            _hasBack = true;
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_speed, 0f);
    }

    private void Enable(object obj)
    {
        gameObject.SetActive(true);
        _entryTime = Time.time;
        _hasBack = false;
        _speed = Mathf.Abs(_speed);

        HatInfo info = (HatInfo)obj;
        transform.position = info.Position;
        _isRight = info.ThrewFromRight;
        _speed = (_isRight) ? _speed : _speed * -1;
        Debug.Log("isRight, velo: " + _isRight + ", " + _speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            EventsManager.Instant.NotifyObservers(GameEnums.EEvents.HatOnBackToPlayer, null);
        }
    }
}
