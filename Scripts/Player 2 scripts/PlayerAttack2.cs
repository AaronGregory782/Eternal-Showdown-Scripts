using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack2 : MonoBehaviour
{
    public Animator anim;

    private GameObject attackArea = default;

    private bool attacking2 = false;

    private float timeToAttack = 0.75f;
    private float timer = 0f;

    [SerializeField] public bool Isblocking2 = false;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

         if (Gamepad.all[1].buttonNorth.isPressed)
        {
            Isblocking2 = true;
        }
        else
        {
            Isblocking2 = false;
        }

        if(Gamepad.all[1].buttonWest.isPressed)
        {
             if (Isblocking2 == false) 
            {
                Attack2();
            }
        }

        // Checks to see if the character presses the attack key and if so the character attacks

        if(attacking2)
        {
            timer += Time.deltaTime;
            anim.SetBool("IsAttacking2",true);

            // Plays the attack animation during the attack animation

            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking2 = false;
                anim.SetBool("IsAttacking2",false);
                attackArea.SetActive(attacking2);

                // starts a timer during which the character will attack and once the character stops attacking the animation stops
            }

        }

    }

    private void Attack2()
    {
        attacking2 = true;
        attackArea.SetActive(attacking2);
    }
}
