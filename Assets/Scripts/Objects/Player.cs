using UnityEngine;

[RequireComponent(typeof(SpaceEntity))]
[RequireComponent(typeof(DamageSystem))]
public class Player : MonoBehaviour
{
    /**
     * Player controls
     **/

    public Collider2D arena;
    public GUIScript gui;
    StageComposer stage;

    SpaceEntityConfig config;
    DamageSystem dmgsys;

    void Start()
    {
        config = GetComponent<SpaceEntity>().config;
        dmgsys = GetComponent<DamageSystem>();

        if (config == null)
            Debug.LogError("[Player] Config missing!");

        stage = StageComposer.Instance;
    }

    void SpecialAttack()
    {

    }

    void SwitchSpecial(int which)
    {

    }
    
    /// GameMessage
    void msg__Death()
    {
        gui.SetHealth(0);
        Debug.Log("OOF *yeets away*");

        stage.Die();
    }

    /// GameMessage
    void msg__Damage(int dmg)
    {
        gui.SetHealth(dmgsys.Health);
        Debug.Log("-1 HP");
    }

    void Update()
    {
        float moveH = Input.GetAxis ("Horizontal");
        float moveV = Input.GetAxis ("Vertical");

        Vector2 newPos = transform.position;

        // Attack type
        if (Input.GetKeyDown("space"))      dmgsys.Shoot(config.SpeedH);
        else if (Input.GetKeyDown("q") 
            || Input.GetKeyDown("e"))       SpecialAttack();
        else if(Input.GetKeyDown("1"))      SwitchSpecial(1); // rockets
        else if(Input.GetKeyDown("2"))      SwitchSpecial(2); // laser
        else if(Input.GetKeyDown("3"))      SwitchSpecial(3); // vertical clear
        
        // Move:
        if (moveV != 0.0f)             newPos.y += moveV * config.SpeedV * Time.deltaTime;
        else if (moveH != 0.0f)        newPos.x += moveH * config.SpeedH * Time.deltaTime;

        //if (arena.bounds.Contains(newPos))
            transform.position = newPos;
    }
}
