using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
  [SerializeField] Slider volumeSlider;
  [SerializeField] Slider difficultySlider;
  [SerializeField] float defaultVolume = 8f;
  [SerializeField] float defaultDifficulty = 0f;

  // Start is called before the first frame update
  void Start()
  {
    volumeSlider.value = PlayerPrefsController.GetMasterVolume();
    difficultySlider.value = PlayerPrefsController.GetDifficulty();
  }

  // Update is called once per frame
  void Update()
  {
    MusicPlayer musicPlayer = FindObjectOfType<MusicPlayer>();

    if (musicPlayer)
    {
      musicPlayer.SetVolume(volumeSlider.value / 10);
    }
  }

  public void SetDefaults()
  {
    volumeSlider.value = defaultVolume;
    difficultySlider.value = defaultDifficulty;
  }

  void OnDestroy()
  {
    PlayerPrefsController.SetMasterVolume(volumeSlider.value);
    PlayerPrefsController.SetDifficulty(difficultySlider.value);
  }
}
