using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  [SerializeField] float speed = 5f;
  [SerializeField] int damage = 1;

  // Update is called once per frame
  void Update()
  {
    transform.Translate(Vector2.right * Time.deltaTime * speed, Space.World);
  }

  void OnTriggerEnter2D(Collider2D collider)
  {
    var attacker = collider.GetComponent<Attacker>();
    var health = collider.GetComponent<Health>();

    if (attacker && health)
    {
      health.ReceiveDamage(damage);
      Destroy(gameObject);
    }

  }
}
