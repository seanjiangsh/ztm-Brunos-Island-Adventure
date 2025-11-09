using UnityEngine;
using UnityEngine.Events;

namespace RPG.Core
{
  public class EventManager
  {
    public static event UnityAction<float> OnChangePlayerHealth;
    public static event UnityAction<int> OnChangePlayerPotion;

    public static void RaiseChangePlayerHealth(float newHealthPoints)
    {
      OnChangePlayerHealth?.Invoke(newHealthPoints);
    }

    public static void RaiseChangePlayerPotion(int newPotionCount)
    {
      OnChangePlayerPotion?.Invoke(newPotionCount);
    }
  }
}