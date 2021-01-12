using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyConfig", menuName = "Space Impact/Enemy", order = 2)]
public class EnemyConfig : SpaceEntityConfig
{
    [Header("Attacks")]
    public bool Attacks = true;
    public float AttackSpeedMin = 0.3f;
    public float AttackSpeedMax = 1f;
    public int BulletSpeed = 20;

    [Header("Game")]
    public GameObject Prefab;
    public int Score = 20;
}
