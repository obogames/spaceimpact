using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public float Speed = 30f;
    public string Owner {get; set;}
    public int Damage = 1;
    public int Team {get; set;}
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * Speed;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.name != "Bounds" && !other.gameObject.name.Contains("Bullet"))
        {
            if (other.TryGetComponent(out DamageSystem dmgsys))
            {
                // each bullet has its dedicated team to prevent friendly fire && wasted bullets
                if (Team == dmgsys.Team)
                    return;
            }

            // Bullet has hit enemy
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // Went out of the screen
        if (transform.position.magnitude >= 100f)
            Destroy(gameObject);
    }
}
