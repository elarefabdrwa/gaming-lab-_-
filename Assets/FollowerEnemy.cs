
using UnityEngine;

public class FollowerEnemy : MonoBehaviour
{
    public float speed = 3f;
    public int damage = 1;

    private Transform player;
    private SpriteRenderer sr;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
            );

            if (sr != null)
            {
                sr.flipX = player.position.x < transform.position.x;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats stats = other.GetComponent<PlayerStats>();

            if (stats != null)
            {
                stats.TakeDamage(damage);
            }
        }
    }
}
    