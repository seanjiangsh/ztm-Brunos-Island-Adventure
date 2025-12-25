using System.Collections.Generic;
using UnityEngine;
using RPG.Core;

namespace RPG.Quests
{
  public class Inventory:MonoBehaviour
  {
    public List<QuestItemSO> items = new(); 

    private void OnEnable()
    {
      EventManager.OnTreasureChestUnlocked += HandleTreasureChestUnlocked;
    }

    private void OnDisable()
    {
      EventManager.OnTreasureChestUnlocked -= HandleTreasureChestUnlocked;
    }

    public void HandleTreasureChestUnlocked(QuestItemSO item)
    {
      items.Add(item);
      Debug.Log($"Added {item.itemName} to inventory.");
    }
  }
}