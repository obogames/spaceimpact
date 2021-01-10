using UnityEngine;

[CreateAssetMenu(fileName = "New AlienConfig", menuName = "Space Impact/Alien", order = 1)]
public class AlienConfig : ScriptableObject
{
    #region Stats
    [Header("Stats")]
    public int Health;
    public int Damage;
    public float SpeedH;
    public float SpeedV;
    public bool Attacks;
    #endregion

    #region Animation
    [Header("Render")]
    public Sprite[] AnimSprites;
    public bool IsAnimated => AnimSprites.Length >= 2;
    public float AnimSpeed = 0.300f;
    #endregion
    

}
