using System;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public string nextLevel = "Stage2";
    public Collider2D arena;
    public GUIScript gui;

    [Space]
    public Transform[] spawns;

    public int debugStartAtEnemy = 0;
    public int debugEndAtEnemy = 0;
    // @TODO: powerups

    [Serializable]
    public struct EnemySpawn
    {
        public float timeAt;
        public int spawner;
        public EnemyConfig Enemy;

        [Space(6)]
        public Vector3 MoveVAmpFreqPhase;
    }
    
    [Space]
    public EnemySpawn[] enemies;

    public bool BossDead {get; set;} = false;
    float timer = 0.0f;
    int enemy_i; // current enemy

    private void Awake()
    {
        Setup();
    }

    public void Setup()
    {
        timer = 0.0f;
        enemy_i = debugStartAtEnemy;
        BossDead = false;

        if (debugStartAtEnemy > 0)
        {
            // fast forward to debugging enemy
            timer = enemies[debugStartAtEnemy].timeAt - 1f;

            if (debugEndAtEnemy == 0)
                debugEndAtEnemy = enemies.Length;
        }
    }
    
    void Update()
    {
        if (enemy_i >= debugEndAtEnemy)
        {
            if (BossDead) {
                // @TODO: wait a bit in a coroutine or sth
                Debug.Log("[Spawner] Boss killed! Loading next level...");
                SceneManager.LoadScene(nextLevel);
            }
            
            return;
        }

        timer += Time.deltaTime;
        var nextEnemy = enemies[enemy_i];

        if (timer >= nextEnemy.timeAt)
        {
            // Spawns the next enemy
            enemy_i++;
            var config = nextEnemy.Enemy;
            var SpawnPoint = spawns[nextEnemy.spawner];
            var obj = Instantiate(config.Prefab, SpawnPoint.position, SpawnPoint.rotation);

            if (obj.TryGetComponent(out SpaceEntity se))
                se.config = config;
            else
                Debug.LogError("[Spawner] Alien has no SpaceEntity component attached!");

            if (obj.TryGetComponent(out Alien alien))
            {
                alien.gameObject.name = $"[{enemy_i}] {config.name}";

                // Sets up Alien script automatically
                if (alien.spawner == null)
                    alien.spawner = this;

                if (alien.arena == null)
                    alien.arena = this.arena;

                if (alien.gui == null)
                    alien.gui = this.gui;

                if (alien.config == null)
                    alien.config = config;

                // Set movement
                alien.MoveVAmp = nextEnemy.MoveVAmpFreqPhase.x;
                alien.MoveVFreq = nextEnemy.MoveVAmpFreqPhase.y;
                alien.MoveVPhase = nextEnemy.MoveVAmpFreqPhase.z;
            }
            else
                Debug.LogError("[Spawner] Alien has no Alien component attached!");
        }
    }
}
