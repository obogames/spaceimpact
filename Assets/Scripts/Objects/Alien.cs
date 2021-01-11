using UnityEngine;

[RequireComponent(typeof(SpaceEntity))]
[RequireComponent(typeof(SimpleAnimator))]
[RequireComponent(typeof(DamageSystem))]
public class Alien : MonoBehaviour 
{
    /**
     * Alien controls
     * shoot
     * up, down, left
     **/
    public Collider2D arena;

    int moveH = -1;

    EnemyConfig config;
    DamageSystem dmg;

    void Start()
    {
        config = GetComponent<SpaceEntity>().config as EnemyConfig;
        dmg = GetComponent<DamageSystem>();

        ScheduleShoot();
    }

    float timer = 0.0f;
    float shootTime = 0.0f;

    void Update()
    {
        // Automaticly moves to the left
        Vector2 newPos = transform.position;

        newPos.x += moveH * config.SpeedH * Time.deltaTime;

        if (config.Attacks)
        {
            // Shoot every once in a while
            timer += Time.deltaTime;

            if (timer >= shootTime)
            {
                // Time to shoot
                dmg.Shoot(moveH * config.BulletSpeed);
                ScheduleShoot();
            }
        }

        // Mathf.Sin()

        // if (arena.bounds.Contains(newPos))
        transform.position = newPos;
    }

    void ScheduleShoot()
    {
        shootTime = Random.Range(config.AttackSpeedMin, config.AttackSpeedMax);
        timer = 0.0f;
    }
}