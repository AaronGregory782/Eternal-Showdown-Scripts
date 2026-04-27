using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 10;

    // Sets how much damage an attack does

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.TryGetComponent<Health2>(out Health2 health))
      {
        health.Damage(damage);
      }
    }
}
