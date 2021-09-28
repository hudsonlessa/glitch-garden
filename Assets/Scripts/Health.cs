using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
  [SerializeField] int health = 3;
  [SerializeField] GameObject deathParticles;

  public void ReceiveDamage(int damage)
  {
    health -= damage;

    if (health <= 0)
    {
      TriggerDeathParticles();
      Destroy(gameObject);
    }
  }

  private void TriggerDeathParticles()
  {
    if (deathParticles)
    {
      Instantiate(deathParticles, transform.position, transform.rotation);
    }
  }
}
