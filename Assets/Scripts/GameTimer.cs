using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
  [Tooltip("Time left to finish the level in seconds.")]
  [SerializeField] float levelTime = 10;
  LevelController levelController;

  void Start()
  {
    levelController = FindObjectOfType<LevelController>();
  }

  // Update is called once per frame
  void Update()
  {
    if (levelController.GetLevelTimerFinished())
    {
      return;
    }

    GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

    bool timerFinished = Time.timeSinceLevelLoad >= levelTime;

    if (timerFinished)
    {
      levelController.SetLevelTimerFinished(true);
    }
  }
}
