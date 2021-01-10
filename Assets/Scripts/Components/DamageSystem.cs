using UnityEngine;


[RequireComponent(typeof(SpaceEntity))]
public class DamageSystem : MonoBehaviour 
{
    public int Health { get; private set; }
    public GameObject death;

    public Transform firePoint;
    public GameObject bulletPrefab;

    SpaceEntityConfig config;

    void Start()
    {
        config = GetComponent<SpaceEntity>().config;

        Health = config.Health;
    }

    public void Shoot()
    {
        var obj = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        var bullet = obj.GetComponent<Bullet>();
        bullet.Owner = name;
        bullet.Damage = config.Damage;
    }

    public bool Hit(int dmg)
    {
        Health -= dmg;

        if (Health <= 0)
        {
            // @todo: instantiate death animation
            Instantiate(death);
            SendMessage("msg__Death");

            Destroy(gameObject);
            return true;
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Bullet"))
        {
            int dmg = other.GetComponent<Bullet>().Damage;

            // got hit by a bullet
            Hit(dmg);
        }
    }
}
