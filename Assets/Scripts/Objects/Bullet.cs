using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public float Speed = 30f;
    public string Owner {get; set;}
    public int Damage = 1;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * Speed;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        //if (other.GetComponent<IDamageable>())
        var cname = other.gameObject.name;

        // @todo: maybe do enemies & player layers?
        if (cname != Owner && cname != "Bounds" && !cname.Contains("Bullet"))
            Destroy(gameObject);
    }

    private void Update()
    {
        // Went out of the screen
        if (transform.position.magnitude >= 100f)
            Destroy(gameObject);
    }
}
