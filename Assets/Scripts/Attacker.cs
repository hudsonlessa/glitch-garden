using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
  float speed = 1f;
  GameObject currentTarget;
  Animator animator;

  void Awake()
  {
    FindObjectOfType<LevelController>().CountAttacker();
  }

  void Start()
  {
    animator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    transform.Translate(Vector2.left * Time.deltaTime * speed);

    if (!currentTarget)
    {
      animator.SetBool("isAttacking", false);
    }
  }

  public void SetMovementSpeed(float speed)
  {
    this.speed = speed;
  }

  public void Attack(GameObject target)
  {
    currentTarget = target;
    animator.SetBool("isAttacking", true);
  }

  public void DealDamage(int damage)
  {
    if (currentTarget)
    {
      Health health = currentTarget.GetComponent<Health>();

      if (health)
      {
        health.ReceiveDamage(damage);
      }
    }
  }

  void OnDestroy()
  {
    LevelController levelController = FindObjectOfType<LevelController>();

    if (levelController)
    {
      levelController.DiscountAttacker();
    }
  }
}
