using UnityEngine;
using System;
using RPG.Utility;

namespace RPG.Character
{
  public class Health : MonoBehaviour
  {
    [NonSerialized] public float healthPoints = 0f;

    private bool isDefeated = false;

    private Animator animatorCmp;
    private BubbleEvent bubbleEventCmp;

    private void Awake()
    {
      animatorCmp = GetComponentInChildren<Animator>();
      bubbleEventCmp = GetComponentInChildren<BubbleEvent>();
    }

    private void OnEnable()
    {
      bubbleEventCmp.OnBubbleCompleteDefeat += HandleBubbleCompleteDefeat;
    }

    private void OnDisable()
    {
      bubbleEventCmp.OnBubbleCompleteDefeat -= HandleBubbleCompleteDefeat;
    }

    public void TakeDamage(float damage)
    {
      healthPoints = Mathf.Max(healthPoints - damage, 0);

      if (healthPoints <= 0 && !isDefeated)
      {
        Defeated();
      }
    }

    private void Defeated()
    {
      if (isDefeated) return;

      animatorCmp.SetTrigger(Constants.ANIMATOR_IS_DEFEATED_PARAM);
      isDefeated = true;
    }

    private void HandleBubbleCompleteDefeat()
    {
      Destroy(gameObject);
    }
  }
}