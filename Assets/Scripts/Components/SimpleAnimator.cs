using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(SpaceEntity))]
public class SimpleAnimator : MonoBehaviour
{
    SpaceEntityConfig config;
    SpriteRenderer m_Renderer;
    public bool DestroyAfterLoop = false;

    void Start()
    {
        config = GetComponent<SpaceEntity>().config;

        m_Renderer = GetComponent<SpriteRenderer>();

        if (m_Renderer == null)
            Debug.LogError($"[{name}.Animator] SpriteRenderer missing!");
        
        if (config == null)
            Debug.LogError($"[{name}.Animator] Config missing!");

        Animate();
    }

    void Update()
    {
        if (config.IsAnimated)
            Animate();
    }

    int frame = 0;
    float timer = 0.0f;

    void Animate()
    {
        timer += Time.deltaTime;

        if (timer >= config.AnimSpeed)
        {
            if (frame >= config.AnimSprites.Length)
            {
                // Loop resets
                frame = 0;

                // Destroys object after first loop:
                if (DestroyAfterLoop)
                {
                    Destroy(gameObject);
                    return;
                }
            }
            m_Renderer.sprite = config.AnimSprites[frame];
            frame++;

            // Reset timer
            timer = timer - config.AnimSpeed;
        }
    }
}
