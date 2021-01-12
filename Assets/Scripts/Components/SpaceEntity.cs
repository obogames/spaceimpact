using UnityEngine;

public class SpaceEntity : MonoBehaviour
{
    public SpaceEntityConfig config;

    protected void Start()
    {
        if (config == null)
            Debug.LogError("[SpaceEntity] Config missing!");
    }

    private void Update()
    {
        // Went out of the screen
        if (transform.position.x <= -100f)
            Destroy(gameObject);
        // Cover edge cases (?)
        else if (transform.position.magnitude >= 300f)
            Destroy(gameObject);
    }
}
