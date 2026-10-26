
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxSpeed;
    public int damage;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Flip()
    {
        sr.flipX = !sr.flipX;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats playerStats = FindObjectOfType<PlayerStats>();

            if (playerStats != null)
            {
                playerStats.TakeDamage(damage);
                Flip();
            }
           
        }
        else if (other.CompareTag("Wall"))
        {
            Flip();
        }
    }
}
