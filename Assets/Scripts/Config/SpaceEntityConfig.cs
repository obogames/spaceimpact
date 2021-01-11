using UnityEngine;

[CreateAssetMenu(fileName = "New SpaceEntity", menuName = "Space Impact/Space Entity", order = 1)]
public class SpaceEntityConfig : ScriptableObject
{
    public int Team = 2;

    [Header("Stats")]
    public int Health = 1;
    public bool Moves = true;
    public int SpeedH = 10;
    public int SpeedV = 18;

    [Header("Render")]
    public Sprite[] AnimSprites;
    public bool IsAnimated => AnimSprites.Length >= 2;
    public float AnimSpeed = 0.300f;
}