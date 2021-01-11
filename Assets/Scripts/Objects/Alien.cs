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
    public GUIScript gui;
    public Spawner spawner;
    GameStatus stage;

    [Space(10)]
    public float MoveVAmp = 5f;
    public float MoveVFreq = 1f;
    public float MoveVPhase = 0f;

    int moveH = -1;
    Vector2 m_StatPosition;

    EnemyConfig config;
    DamageSystem dmg;

    void Start()
    {
        config = GetComponent<SpaceEntity>().config as EnemyConfig;
        dmg = GetComponent<DamageSystem>();

        m_StatPosition = transform.position;

        stage = GameStatus.Instance;

        ScheduleShoot();
    }

    /// GameMessage
    void msg__Death() 
    {
        stage.AddScore(config.Score);
        gui.SetScore(stage.Score);

        if (config is BossConfig)
        {
            // Boss dead -> signal the spawner
            spawner.BossDead = true;
        }
    }

    /// GameMessage
    void msg__Damage() { }
    
    float timer = 0.0f;
    float shootTime = 0.0f;

    void Update()
    {
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

        if (config.Moves)
        {
            // Automaticly moves to the left
            Vector2 newPos = transform.position;

            newPos.x += moveH * config.SpeedH * Time.deltaTime;

            if (config.SpeedV != 0)
            {
                // Sine movement
                var A = MoveVAmp;
                var f = MoveVFreq * config.SpeedV;
                var phi = MoveVPhase;
                var t = Time.time;

                newPos.y = A * Mathf.Sin(f * t / Mathf.PI/2 + phi);
            }

            // if (arena.bounds.Contains(newPos))
            transform.position = newPos;
        }
    }

    void ScheduleShoot()
    {
        shootTime = Random.Range(config.AttackSpeedMin, config.AttackSpeedMax);
        timer = 0.0f;
    }
}