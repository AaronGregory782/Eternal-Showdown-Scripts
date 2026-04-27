using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;

    private GameObject attackArea = default;

    private bool attacking = false;

    private float timeToAttack = 0.75f;
    private float timer = 0f;

    [SerializeField] public bool Isblocking = false;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (Gamepad.all[0].buttonNorth.isPressed)
        {
            Isblocking = true;
        }
        else
        {
            Isblocking = false;
        }

        if(Gamepad.all[0].buttonWest.isPressed)
        {
            if (Isblocking == false) 
            {
                Attack();
            }
        }

        // Checks to see if the character presses the attack key and if so the character attacks

        if(attacking)
        {
            timer += Time.deltaTime;
            anim.SetBool("IsAttacking",true);

            // Plays the attack animation during the attack animation

            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                anim.SetBool("IsAttacking",false);
                attackArea.SetActive(attacking);

                // starts a timer during which the character will attack and once the character stops attacking the animation stops
            }

        }

    }

    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }
}
