using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackArea2 : MonoBehaviour
{
    private int damage2 = 10;

    // Sets how much damage an attack does;
   
    private void OnCollisionEnter2D(Collision2D collision)
   {
    if (collision.gameObject.TryGetComponent<Health>(out Health health))
    {
        health.Damage(damage2);
    }
   }


}
