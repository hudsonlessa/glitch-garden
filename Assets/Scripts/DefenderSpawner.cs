using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
  Defender defender;
  GameObject defenderParent;
  const string DEFENDER_PARENT_NAME = "Defenders";

  void Start()
  {
    CreateDefenderParent();
  }

  private void CreateDefenderParent()
  {
    defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);

    if (!defenderParent)
    {
      defenderParent = new GameObject(DEFENDER_PARENT_NAME);
    }
  }

  private void OnMouseDown()
  {
    if (defender)
    {
      PlaceDefender(GetSquareClicked());
    }
  }

  public void SetSelectedDefender(Defender defender)
  {
    this.defender = defender;
  }

  private void PlaceDefender(Vector2 gridPosition)
  {
    var starsDisplay = FindObjectOfType<StarsDisplay>();
    int defenderCost = defender.GetStarCost();

    if (starsDisplay.HaveEnoughStars(defenderCost))
    {
      SpawnDefender(gridPosition);
      starsDisplay.RemoveStars(defenderCost);
    }
  }

  private void SpawnDefender(Vector2 gridPosition)
  {
    Defender newDefender = Instantiate(defender, gridPosition, transform.rotation);
    newDefender.transform.parent = defenderParent.transform;
  }

  private Vector2 GetSquareClicked()
  {
    Vector2 screenClickPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    Vector2 worldClickPosition = Camera.main.ScreenToWorldPoint(screenClickPosition);
    Vector2 gridClickPosition = SnapToGrid(worldClickPosition);
    return gridClickPosition;
  }

  private Vector2 SnapToGrid(Vector2 worldPosition)
  {
    float newX = Mathf.RoundToInt(worldPosition.x);
    float newY = Mathf.RoundToInt(worldPosition.y);
    return new Vector2(newX, newY);
  }
}
