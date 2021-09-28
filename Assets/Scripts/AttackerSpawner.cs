using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
  bool spawn = true;
  [SerializeField] float minSpawnDelay = 1f;
  [SerializeField] float maxSpawnDelay = 5f;
  [SerializeField] Attacker[] attackersPrefabs;

  // Start is called before the first frame update
  IEnumerator Start()
  {
    while (spawn)
    {
      yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
      SpawnAttacker();
    }
  }

  public void StopSpawning()
  {
    spawn = false;
  }

  void SpawnAttacker()
  {
    int randomIndex = Random.Range(0, attackersPrefabs.Length);

    Attacker randomAttacker = attackersPrefabs[randomIndex];

    Spawn(randomAttacker);
  }

  void Spawn(Attacker randomAttacker)
  {
    Attacker attacker = Instantiate(randomAttacker, transform.position, transform.rotation);
    attacker.transform.parent = transform;
  }
}
