using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collider)
  {
    GameObject colliderObject = collider.gameObject;

    if (colliderObject.GetComponent<Defender>())
    {
      GetComponent<Attacker>().Attack(colliderObject);
    }
  }
}
