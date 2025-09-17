using UnityEngine;
using UnityEngine.Events;

namespace RPG.Utility
{
  public class BubbleEvent : MonoBehaviour
  {
    public UnityAction OnBubbleStartAttack;
    public UnityAction OnBubbleCompleteAttack;

    private void OnStartAttack()
    {
      OnBubbleStartAttack.Invoke();
    }

    private void OnCompleteAttack()
    {
      OnBubbleCompleteAttack.Invoke();
    }
  }
}