using UnityEngine;


[RequireComponent(typeof(SpaceEntity))]
public class DamageSystem : MonoBehaviour 
{
    public int Health { get; private set; }
    public bool MainCharacter { get; private set; }
    public int Team => config.Team;
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
        bullet.Team = config.Team;

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
        if (other.gameObject.name != "Bounds")
        {
            int myTeam = config.Team;

            if (other.TryGetComponent(out Bullet bullet))
            {
                int yoTeam = bullet.Team;

                // Got hit by a bullet
                if (myTeam != yoTeam)
                    Hit(bullet.Damage);
            }
            else
            {
                if (other.TryGetComponent(out DamageSystem dmgsys))
                {
                    int yoTeam = dmgsys.Team;

                    if (myTeam == yoTeam)
                        return;
                }

                // Collides with something else
                Hit(MainCharacter ? 1 : Health);
            }
        }
    }
}
