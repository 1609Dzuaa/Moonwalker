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
        EventsManager.Instance.SubcribeToAnEvent(GameEnums.EEvents.HatOnBeingThrew, Enable);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        EventsManager.Instance.SubcribeToAnEvent(GameEnums.EEvents.HatOnBeingThrew, Enable);
        _entryTime = Time.time;
    }

    private void OnDisable()
    {
        EventsManager.Instance.UnSubcribeToAnEvent(GameEnums.EEvents.HatOnBeingThrew, Enable);
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
        HatInfo info = (HatInfo)obj;

        transform.position = info.Position;
        _isRight = info.ThrewFromRight;
    }
}