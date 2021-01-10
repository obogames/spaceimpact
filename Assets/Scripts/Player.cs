using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    SpriteRenderer m_Renderer;
    public PlayerConfig config;
    public Collider2D arena;

    void Start() 
    {
        m_Renderer = GetComponent<SpriteRenderer>();

        if (m_Renderer == null)
            Debug.LogError("[Alien] SpriteRenderer missing!");
        
        if (config == null)
            Debug.LogError("[Alien] Config missing!");
    }

    void Shoot()
    {
        
    }

    void SpecialAttack()
    {

    }

    void SwitchSpecial(int which)
    {

    }
    
    void Update()
    {
        float moveH = Input.GetAxis ("Horizontal");
        float moveV = Input.GetAxis ("Vertical");

        Vector2 newPos = transform.position;

        if (Input.GetKeyDown("space"))      Shoot();
        else if (Input.GetKeyDown("q") 
            || Input.GetKeyDown("e"))       SpecialAttack();
        else if(Input.GetKeyDown("1"))      SwitchSpecial(1); // rockets
        else if(Input.GetKeyDown("2"))      SwitchSpecial(2); // laser
        else if(Input.GetKeyDown("3"))      SwitchSpecial(3); // vertical clear
        else if (moveV != 0.0f)             newPos.y += moveV * config.SpeedH;
        else if (moveH != 0.0f)             newPos.x += moveH * config.SpeedV;

        if (arena.bounds.Contains(newPos))
            transform.position = newPos;
    }
}
