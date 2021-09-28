using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
  [SerializeField] Defender defenderPrefab;
  private SpriteRenderer spriteRenderer;

  // Start is called before the first frame update
  void Start()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
    LabelButtonWithCost();
  }

  private void LabelButtonWithCost()
  {
    Text costText = GetComponentInChildren<Text>();

    if (costText)
    {
      costText.text = defenderPrefab.GetStarCost().ToString();
    }
  }

  void OnMouseDown()
  {
    DefenderButton[] buttons = FindObjectsOfType<DefenderButton>();

    foreach (DefenderButton button in buttons)
    {
      button.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(0, 0, .5f);
    }

    spriteRenderer.color = Color.white;

    FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
  }
}
