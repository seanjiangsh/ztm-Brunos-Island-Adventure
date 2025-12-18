using UnityEngine;
using UnityEngine.Events;

namespace RPG.Core
{
  public class EventManager
  {
    public static event UnityAction<float> OnChangePlayerHealth;
    public static event UnityAction<int> OnChangePlayerPotion;
    public static event UnityAction<TextAsset> OnInitiateDialogue;
    public static event UnityAction OnTreasureChestUnlocked;

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

    public static void RaiseTreasureChestUnlocked()
    {
      OnTreasureChestUnlocked?.Invoke();
    }
  }
}