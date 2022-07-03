using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;
    [SerializeField] int pointsForKillingNormalEnemy = 50;
    [SerializeField] int pointsForKillingRedEnemy = 150;
    Rigidbody2D myRigidbody;
    PlayerMovement player;
    float xSpeed;
    bool wasKilled = false;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2(xSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Normal Enemy" && !wasKilled)
        {
            wasKilled = true;
            Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            FindObjectOfType<GameSession>().AddToScore(pointsForKillingNormalEnemy);
        }
        else if (other.tag == "Red Enemy" && !wasKilled)
        {
            wasKilled = true;
            Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            FindObjectOfType<GameSession>().AddToScore(pointsForKillingRedEnemy);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }

}
