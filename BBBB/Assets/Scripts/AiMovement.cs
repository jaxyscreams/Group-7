using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{
    public GameObject targetFood;
    public float moveSpeed;
    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.Instance.foodLeft.Count > 0)
        {
            if (!targetFood)
            {
                NewTarget();
            }
            transform.position = Vector2.MoveTowards(transform.position, targetFood.transform.position,
                moveSpeed * Time.deltaTime);
            
        }
        else
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position,
                moveSpeed * -1 * Time.deltaTime);
        }
        
    }

    public void NewTarget()
    {
        int targetRandom;
        targetRandom = Random.Range(0, ScoreManager.Instance.foodLeft.Count);
        targetFood = ScoreManager.Instance.foodLeft[targetRandom];
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && ScoreManager.Instance.foodLeft.Count > 0)
        {
            Destroy(other.gameObject);
            GameStateManager.Instance.LoseGame();  
        } else if (other.gameObject.tag == "Player" && ScoreManager.Instance.foodLeft.Count <= 0)
        {
            ScoreManager.Instance.enemiesLeft.Remove(gameObject);
            ScoreManager.Instance.LossOrWin();
            Destroy(gameObject);
        }
    }
}
