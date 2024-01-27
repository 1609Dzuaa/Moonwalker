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
    [SerializeField] Transform _hatPosition;

    Animator _anim;
    Rigidbody2D _rb;
    float _dirX;
    bool _detectedGround;
    bool _isFacingRight;
    bool _canThrowHat = true;

    #region States

    PlayerBaseState _state;
    PlayerIdleState _idle = new();
    PlayerWalkState _walk = new();
    PlayerJumpState _jump = new();
    PlayerHatAttack _hatAttack = new();

    #endregion

    public float MovementSpeed { get => _movementSpeed; }

    public float JumpForce { get => _jumpForce; }

    public float DirX { get => _dirX; }

    public bool DetectedGround { get => _detectedGround; }

    public bool IsFacingRight { get => _isFacingRight; }

    public bool CanThrowHat { get => _canThrowHat; }

    public Animator Animator { get => _anim; }

    public Rigidbody2D Rigidbody2D { get => _rb; set => _rb = value; }

    public PlayerIdleState GetIdleState() => _idle;

    public PlayerWalkState GetWalkState() => _walk;

    public PlayerJumpState GetJumpState() => _jump;

    public PlayerHatAttack GetHatAttack() => _hatAttack;

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
        EventsManager.Instance.SubcribeToAnEvent(GameEnums.EEvents.HatOnBackToPlayer, HatBack);
    }

    // Update is called once per frame
    void Update()
    {
        _dirX = Input.GetAxisRaw("Horizontal");
        _state.UpdateState();
        GroundCheck();
        HandleFlipSprite();
        //Debug.Log("R: " + _isFacingRight);
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

    private void AllowUpdateHatAttack()
    {
        _hatAttack._allowUpdate = true;
        //event cua Hat Attack animation
    }

    private void InvokeHatFunction()
    {
        HatInfo info = new HatInfo(_hatPosition.transform.position, _isFacingRight);
        EventsManager.Instance.NotifyObservers(GameEnums.EEvents.HatOnBeingThrew, info);
        _canThrowHat = false;
    }

    private void HatBack(object obj)
    {
        _canThrowHat = true;
    }

    private void AllowUpdateJump()
    {
        _jump._allowUpdate = true;
    }

}
