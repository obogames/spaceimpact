using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerConfig", menuName = "Space Impact/Player", order = 0)]
public class PlayerConfig : ScriptableObject
{
    #region Stats
    [Header("Stats")]
    public int Health;
    public int Damage;

    public float SpeedH;
    public float SpeedV;
    #endregion

}
