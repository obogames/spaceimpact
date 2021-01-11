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


    private void Update()
    {
        // Went out of the screen
        if (transform.position.magnitude >= 100f)
            Destroy(gameObject);
    }
}
