using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
  [SerializeField] GameObject winLabel;
  [SerializeField] GameObject loseLabel;
  int attackerAmount = 0;
  bool levelTimerFinished = false;
  public float sceneChangeDelay = 4f;

  private void Start()
  {
    winLabel.SetActive(false);
    loseLabel.SetActive(false);
  }

  public void CountAttacker()
  {
    attackerAmount++;
  }

  public void DiscountAttacker()
  {
    attackerAmount--;

    if (attackerAmount <= 0 && levelTimerFinished)
    {
      StartCoroutine(HandleWinCondition());
    }
  }

  IEnumerator HandleWinCondition()
  {
    winLabel.SetActive(true);
    GetComponent<AudioSource>().Play();
    yield return new WaitForSeconds(sceneChangeDelay);
    FindObjectOfType<LevelLoader>().LoadNextScene();
  }

  public void HandleLoseCondition()
  {
    Time.timeScale = 0;
    loseLabel.SetActive(true);
  }

  public bool GetLevelTimerFinished()
  {
    return levelTimerFinished;
  }

  public void SetLevelTimerFinished(bool value)
  {
    levelTimerFinished = value;
    StopSpawners();
  }

  private void StopSpawners()
  {
    AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

    foreach (AttackerSpawner spawner in spawners)
    {
      spawner.StopSpawning();
    }
  }
}
