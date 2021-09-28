using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
  [SerializeField] Projectile projectile;
  [SerializeField] GameObject gun;
  AttackerSpawner laneSpawner;
  Animator animator;

  GameObject projectileParent;
  const string PROJECTILE_PARENT_NAME = "Projectiles";

  void Start()
  {
    SetLaneSpawner();
    animator = GetComponent<Animator>();
    CreateProjectileParent();
  }

  private void SetLaneSpawner()
  {
    AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();

    foreach (AttackerSpawner attackerSpawner in attackerSpawners)
    {
      bool isOnLane = Mathf.Abs(transform.position.y - attackerSpawner.transform.position.y) <= Mathf.Epsilon;

      if (isOnLane)
      {
        laneSpawner = attackerSpawner;
      }
    }
  }

  private void CreateProjectileParent()
  {
    projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);

    if (!projectileParent)
    {
      projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
    }
  }

  void Update()
  {
    if (laneHasAttacker())
    {
      // Change animation state to attack
      animator.SetBool("isAttacking", true);
    }
    else
    {
      // Change animation state to idle
      animator.SetBool("isAttacking", false);
    }
  }

  private bool laneHasAttacker()
  {
    if (laneSpawner.transform.childCount > 0)
    {
      return true;
    }
    return false;
  }

  public void Fire()
  {
    Projectile newProjectile = Instantiate(projectile, gun.transform.position, transform.rotation);
    newProjectile.transform.parent = projectileParent.transform;
  }
}
