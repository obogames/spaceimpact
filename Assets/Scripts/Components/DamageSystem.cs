using UnityEngine;


[RequireComponent(typeof(SpaceEntity))]
public class DamageSystem : MonoBehaviour 
{
    public int Health { get; private set; }
    public bool MainCharacter { get; private set; }
    public GameObject death;

    public Transform firePoint;
    public GameObject bulletPrefab;

    SpaceEntityConfig config;

    void Start()
    {
        config = GetComponent<SpaceEntity>().config;

        Health = config.Health;
        MainCharacter = config is PlayerConfig || config is BossConfig;
    }

    public void Shoot(int? Speed = null)
    {
        var obj = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        var bullet = obj.GetComponent<Bullet>();
        bullet.Owner = name;

        if (Speed != null)
            bullet.Speed = (int) Speed;
    }

    public bool Hit(int dmg)
    {
        Health -= dmg;

        if (Health <= 0)
        {
            Instantiate(death, transform.position, transform.rotation);
            SendMessage("msg__Death");

            Destroy(gameObject);
            return true;
        }

        SendMessage("msg__Damage", dmg);

        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string cname = other.gameObject.name;

        if (cname != "Bounds")
        {
            if (other.TryGetComponent(out Bullet bullet)) 
            {
                // Got hit by a bullet
                if (bullet.Owner == name)
                    return;

                Hit(bullet.Damage);
            }
            else
            {
                // Collides with something else
                Hit(MainCharacter ? 1 : Health);
            }
        }
    }
}
