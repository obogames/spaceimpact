using UnityEngine;

public class SpaceEntity : MonoBehaviour
{
    public SpaceEntityConfig config;
    public int SpawnsAt;

    protected void Start()
    {
        if (config == null)
            Debug.LogError("[SpaceEntity] Config missing!");
    }

    /// GameMessage
    void msg__Death()
    {

    }
}
