using UnityEngine;
using UnityEngine.Events;
using RPG.Quests;

namespace RPG.Core
{
  public class EventManager
  {
    public static event UnityAction<float> OnChangePlayerHealth;
    public static event UnityAction<int> OnChangePlayerPotion;
    public static event UnityAction<TextAsset> OnInitiateDialogue;
    public static event UnityAction<QuestItemSO> OnTreasureChestUnlocked;
    public static event UnityAction<bool> OnToggleUI;

    public static void RaiseChangePlayerHealth(float newHealthPoints)
    {
      OnChangePlayerHealth?.Invoke(newHealthPoints);
    }

    public static void RaiseChangePlayerPotion(int newPotionCount)
    {
      OnChangePlayerPotion?.Invoke(newPotionCount);
    }

    public static void RaiseInitiateDialogue(TextAsset inkJSONAsset)
    {
      OnInitiateDialogue?.Invoke(inkJSONAsset);
    }

    public static void RaiseTreasureChestUnlocked(QuestItemSO questItem)
    {
      OnTreasureChestUnlocked?.Invoke(questItem);
    }

    public static void RaiseToggleUI(bool isOpened)
    {
      OnToggleUI?.Invoke(isOpened);
    }
  }
}