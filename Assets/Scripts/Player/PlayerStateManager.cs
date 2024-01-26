using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    [SerializeField] float _movementSpeed;
    [SerializeField] float _jumpForce;
    [SerializeField] float _radius;
    [SerializeField] LayerMask _groundLayer;
    [SerializeField] Transform _groundCheck;

    Animator _anim;
    Rigidbody2D _rb;
    float _dirX;
    bool _detectedGround;
    bool _isFacingRight = true;

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

    public Animator Animator { get => _anim; }

    public Rigidbody2D Rigidbody2D { get => _rb; set => _rb = value; }

    public PlayerIdleState GetIdleState() => _idle;

    public PlayerWalkState GetWalkState() => _walk;

    public PlayerJumpState GetJumpState() => _jump;

    public PlayerFallState GetFallState() => _fall;

    private void Awake()
    {
        GetReferenceComponents();
    }

    private void GetReferenceComponents()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetupProperties();
    }

    private void SetupProperties()
    {
        _state = _idle;
        _state.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        _dirX = Input.GetAxisRaw("Horizontal");
        _state.UpdateState();
        GroundCheck();
        HandleFlipSprite();
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

    private void HandleFlipSprite()
    {
        if (_isFacingRight && _dirX < 0)
            FlippingSprite();
        else if (!_isFacingRight && _dirX > 0)
            FlippingSprite();
    }

    public void FlippingSprite()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0, 180f, 0);
    }

    private void GroundCheck()
    {
        _detectedGround = Physics2D.OverlapCircle(_groundCheck.position, _radius, _groundLayer);
    }

    private void OnDrawGizmos()
    {
        if (_groundCheck)
            Gizmos.DrawSphere(_groundCheck.transform.position, _radius);
    }
}
