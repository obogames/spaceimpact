using System;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public string nextLevel = "Stage2";

    [Space]
    public Transform SpawnPoint;
    public Collider2D arena;
    public GUIScript gui;

    // @TODO: powerups

    [Serializable]
    public struct EnemySpawn
    {
        [Header("Spawn")]
        public float timeAt;
        public EnemyConfig Enemy;

        [Header("Movement")]
        public float MoveVAmp;
        public float MoveVFreq;
        public float MoveVPhase;
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
        enemy_i = 0;
        BossDead = false;
    }
    
    void Update()
    {
        if (enemy_i >= enemies.Length)
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
            var obj = Instantiate(nextEnemy.Enemy.Prefab, SpawnPoint.position, SpawnPoint.rotation);

            if (obj.TryGetComponent(out SpaceEntity se))
                se.config = nextEnemy.Enemy;

            if (obj.TryGetComponent(out Alien alien))
            {
                // Sets up Alien script automatically
                if (alien.arena == null)
                    alien.arena = this.arena;
                if (alien.gui == null)
                    alien.gui = this.gui;
            }
        }
    }
}
