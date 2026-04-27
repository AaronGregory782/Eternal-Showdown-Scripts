using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private int stocks = 3;
    [SerializeField] public bool blocking = false;

    public GameObject gameoverscreen;
    public GameObject p1stats;
    public GameObject p2stats;
    public GameObject ReturnButton;

    public TextMeshProUGUI Livecounter;


    // Update is called once per frame

    public void Damage(int amount)
    {
        if (blocking == true)
        {
            return;
        }
        
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

      
        this.health -= amount;
        

        if(health <= 0)
        {

            stocks = stocks - 1;
            gameObject.transform.position = new Vector3(0f ,0f , 0f);
            health = 100;

            if (stocks <= 0)
            {
                Die();
            }
        }
    }

    void Update()
    {
        if (Gamepad.all[0].buttonNorth.isPressed)
        {
            blocking = true;
        }
        else
        {
            blocking = false;
        }


        Livecounter.text = "Lives: " + stocks + " Health: " + health;
        

    }
    private void Die()
    {
        Debug.Log("I am Dead!");    
        Destroy(gameObject);
        gameoverscreen.SetActive(true);
        p1stats.SetActive(false);
        p2stats.SetActive(false);
        ReturnButton.SetActive(true);
        
    }
}
