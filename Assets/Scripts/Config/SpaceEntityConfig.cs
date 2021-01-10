using UnityEngine;

[CreateAssetMenu(fileName = "New SpaceEntity", menuName = "Space Impact/Space Entity", order = 1)]
public class SpaceEntityConfig : ScriptableObject
{
    #region Stats
    [Header("Stats")]
    public int Health = 1;
    public int Damage = 1;
    public int SpeedH = 30;
    public int SpeedV = 22;
    #endregion

    #region Animation
    [Header("Render")]
    public Sprite[] AnimSprites;
    public bool IsAnimated => AnimSprites.Length >= 2;
    public float AnimSpeed = 0.300f;
    #endregion
}