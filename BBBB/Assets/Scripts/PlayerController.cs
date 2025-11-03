using UnityEngine;
[RequireComponent(typeof(PlayerInput))]


public class PlayerController : MonoBehaviour
{
    #region "Movement"

    public static PlayerController Instance;
    public bool canMove = true;
    public float moveSpeed = 6f;
    public Vector2 moveDir;
    private PlayerInput _input;
    
    public bool isMoving;

    #endregion

    private Rigidbody2D playerbody;


    private void Start()
    {
        Instance = this;
        _input = GetComponent<PlayerInput>();
        playerbody = GetComponent<Rigidbody2D>();
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
                moveDir.y = 0;
            }

            if (_input.moveVector.y != 0 && Mathf.Abs(_input.moveVector.y) > Mathf.Abs(_input.moveVector.x)) 
            {
                moveDir.y = _input.moveVector.y;
                moveDir.x = 0;
            }
                

            if (Mathf.Abs(_input.moveVector.y) == Mathf.Abs(_input.moveVector.x))
            {
                moveDir.y = 0;
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

        {
            moveDir = Vector2.zero;
        }

        playerbody.linearVelocity = moveDir * moveSpeed;
    }
}
