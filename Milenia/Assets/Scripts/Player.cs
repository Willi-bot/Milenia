using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public float playerSpeed = 4.5f;

    private int _idleLoops = 0;
    
    private BoxCollider2D _boxCollider;
    private Vector2 _colliderOffset;

    private Animator _animator;
    
    private Vector3 _moveDelta;

    private RaycastHit2D _hit;
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int IdleTime = Animator.StringToHash("IdleTime");
    private static readonly int Blink = Animator.StringToHash("Blink");

    // Start is called before the first frame update
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _colliderOffset = _boxCollider.offset;
        _animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {

        if(_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            _idleLoops++;
            if (_idleLoops == 3000)
            {
                print("Loop trigger set");
                _animator.SetTrigger(Blink);
                _idleLoops = 0;
            }
        }
        else
        {
            _idleLoops = 0;
        }
        
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        
        _animator.SetFloat(Horizontal, x);
        _animator.SetFloat(Vertical, y);

        _moveDelta = new Vector3(x, y, 0);
        
        
        _animator.SetFloat(Speed, _moveDelta.sqrMagnitude);
        
        Vector3 transPos = transform.position;
        Vector3 hitBoxPosition = new Vector3(transPos.x + _colliderOffset.x, 
            transPos.y + _colliderOffset.y, 0);
        
        _hit = Physics2D.BoxCast(hitBoxPosition, _boxCollider.size, 0, 
            new Vector2(0, _moveDelta.y), Mathf.Abs(_moveDelta.y * Time.deltaTime * playerSpeed), 
            LayerMask.GetMask("Default", "MapBounds", "TriggerBox"));
        if (_hit.collider is null)
        {
            transform.Translate(0, _moveDelta.y * (Time.deltaTime * playerSpeed), 0);
        }
        _hit = Physics2D.BoxCast(hitBoxPosition, _boxCollider.size, 0, 
            new Vector2(_moveDelta.x, 0), Mathf.Abs(_moveDelta.x * Time.deltaTime * playerSpeed), 
            LayerMask.GetMask("Default", "MapBounds"));
        if (_hit.collider is null)
        {
            transform.Translate(_moveDelta.x * (Time.deltaTime * playerSpeed),0, 0);
        }
        
        
    }
}
