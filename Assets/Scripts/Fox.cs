using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collider)
  {
    GameObject colliderObject = collider.gameObject;

    if (colliderObject.GetComponent<Gravestone>())
    {
      GetComponent<Animator>().SetTrigger("jump");
    }
    else if (colliderObject.GetComponent<Defender>())
    {
      GetComponent<Attacker>().Attack(colliderObject);
    }
  }
}
