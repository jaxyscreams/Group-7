using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Controller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movementInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove1(InputAction.CallbackContext context)
    {
        Debug.Log("OnMove");
        movementInput = context.ReadValue<Vector2>();
        
    }

    void FixedUpdate() // Use FixedUpdate for physics-based movement
    {
        rb.linearVelocity = movementInput * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            ScoreManager.Instance.AddPlayerScore(25);
        }

        if (other.gameObject.tag == "Player" && ScoreManager.Instance.foodLeft.Count == 0)
        {
            Destroy(gameObject);
            ScoreManager.Instance.LossOrWin();
        }
    }
}   
