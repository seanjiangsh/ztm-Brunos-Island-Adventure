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

    public void HandleTreasureChestUnlocked(QuestItemSO item, bool showUI)
    {
      if (!showUI) return;
      
      items.Add(item);
      Debug.Log($"Added {item.itemName} to inventory.");
    }

    public bool HasItem(QuestItemSO desiredItem)
    {
      bool found = false;
      items.ForEach((QuestItemSO item) =>
      {
        if(item.name == desiredItem.name) found = true;
      });
      return found;
    }

    public void RemoveItem(QuestItemSO itemToRemove)
    {
      items.RemoveAll(item => item.name == itemToRemove.name);
      Debug.Log($"Removed {itemToRemove.itemName} from inventory.");
    }
  }
}