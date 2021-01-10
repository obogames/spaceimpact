using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Alien : MonoBehaviour
{
    public AlienConfig config;
    public int SpawnsAt;
    protected SpriteRenderer m_Renderer;
    
    protected void Start() 
    {
        m_Renderer = GetComponent<SpriteRenderer>();

        if (m_Renderer == null)
            Debug.LogError("[Alien] SpriteRenderer missing!");
        
        if (config == null)
            Debug.LogError("[Alien] Config missing!");

        Animate();
    }

    protected void Update()
    {
        if (config.IsAnimated)
            Animate();
    }

#region Animation
    protected int frame = 0;
    protected float timer = 0.0f;

    protected void Animate() 
    {
        timer += Time.deltaTime;

        if (timer >= config.AnimSpeed)
        {
            // Change frames
            if (frame >= config.AnimSprites.Length)
                frame = 0;
            m_Renderer.sprite = config.AnimSprites[frame];
            frame++;

            // Reset timer
            timer = timer - config.AnimSpeed;
        }
    }
#endregion
}
