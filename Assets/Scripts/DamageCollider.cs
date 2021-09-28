using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D collider)
  {
    FindObjectOfType<LivesDisplay>().RemoveLife();
    Destroy(collider.gameObject);
  }
}
