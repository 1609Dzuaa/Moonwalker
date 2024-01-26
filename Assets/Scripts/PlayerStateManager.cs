using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    [SerializeField] float _movementSpeed;
    [SerializeField] float _jumpForce;
    [SerializeField] float _radius;
    [SerializeField] LayerMask _groundLayer;

    Rigidbody2D _rb;
    Transform _groundCheck;
    float _dirX;
    bool _detectedGround;

    #region States

    PlayerBaseState _state;
    PlayerIdleState _idle = new();
    PlayerWalkState _walk = new();
    PlayerJumpState _jump = new();
    PlayerFallState _fall = new();

    #endregion

    public float MovementSpeed { get => _movementSpeed; }

    public float JumpForce { get => _jumpForce; }

    public float DirX { get => _dirX; }

    public bool DetectedGround { get => _detectedGround; }

    public Rigidbody2D Rigidbody2D { get => _rb; set => _rb = value; }

    public PlayerIdleState GetIdleState() => _idle;

    public PlayerWalkState GetWalkState() => _walk;

    public PlayerJumpState GetJumpState() => _jump;

    public PlayerFallState GetFallState() => _fall;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _groundCheck = GetComponent<Transform>();
        _state = _idle;
        _state.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        _dirX = Input.GetAxis("Horizontal");
        _state.UpdateState();
        GroundCheck();
        Debug.Log("G: " + _detectedGround);
    }

    private void FixedUpdate()
    {
        _state.FixedUpdateState();
    }

    public void ChangeState(PlayerBaseState state)
    {
        _state.ExitState();
        _state = state;
        _state.EnterState(this);
    }

    private void GroundCheck()
    {
        _detectedGround = Physics2D.OverlapCircle(_groundCheck.position, _radius, _groundLayer);
    }
}
