using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
  int currentSceneIndex;
  [SerializeField] int delayInSeconds = 3;

  void Start()
  {
    currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    if (currentSceneIndex == 0) { LoadStartScreenDelayed(); }
  }

  public void LoadStartScreenDelayed()
  {
    StartCoroutine(DelaySceneLoad("Start Screen"));
  }

  public void LoadScreen(string sceneName)
  {
    SceneManager.LoadScene(sceneName);
  }

  public void LoadStartScreen()
  {
    Time.timeScale = 1;
    SceneManager.LoadScene("Start Screen");
  }

  public void LoadNextScene()
  {
    SceneManager.LoadScene(currentSceneIndex + 1);
  }

  public void RestartScene()
  {
    Time.timeScale = 1;
    SceneManager.LoadScene(currentSceneIndex);
  }

  private IEnumerator DelaySceneLoad(string sceneName)
  {
    yield return new WaitForSeconds(delayInSeconds);
    SceneManager.LoadScene(sceneName);
  }

  public void LoadLoseScreen()
  {
    SceneManager.LoadScene("Lose Screen");
  }

  public void QuitGame()
  {
    Application.Quit();
  }
}
