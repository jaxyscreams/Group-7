using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInput))]


public class PlayerController : MonoBehaviour
{
    #region "Movement"

    public static PlayerController Instance;
    public bool canMove = true;
    public float moveSpeed = 6f;
    public Vector2 moveDir;
    private PlayerInput _input;
    private int ShieldAmount    {
        get { return _shieldAmount;} set { _shieldAmount = value; }
    }
    public int _shieldAmount;

    public bool isMoving;

    #endregion

    private Rigidbody2D playerbody;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;    
        }
        else
        {
            Destroy(gameObject);
        }
        _input = GetComponent<PlayerInput>();
        playerbody = GetComponent<Rigidbody2D>();
        moveSpeed += UpgradeManager.Instance._p1SpeedBonus;
        _shieldAmount = UpgradeManager.Instance._p1Shield;
    }

    private void Update()
    {
        UpdateMovement();
    }


private void UpdateMovement()
{

    if (canMove)
    {
     if (_input.moveVector.x != 0 && Mathf.Abs(_input.moveVector.x) > Mathf.Abs(_input.moveVector.y))
     {
         moveDir.x = _input.moveVector.x;
       
     }
    
      if (_input.moveVector.y != 0 && Mathf.Abs(_input.moveVector.y) > Mathf.Abs(_input.moveVector.x))
       {
        moveDir.y = _input.moveVector.y;
   
      }


      if (Mathf.Abs(_input.moveVector.y) == Mathf.Abs(_input.moveVector.x))
     {
        
        moveDir.x = _input.moveVector.x;
       }

       if (_input.moveVector == Vector2.zero)
       {
           moveDir = Vector2.zero;
        }

        if (Mathf.Abs(moveDir.magnitude) > 0)
     {
        isMoving = true;
      }
      if (Mathf.Abs(moveDir.magnitude) !> 0)
      {
        isMoving = false;
      }
    }
    else
    { moveDir = Vector2.zero; }
    playerbody.linearVelocity = moveDir * moveSpeed;
}
}
