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

    private void Awake()
    {
      animatorCmp = GetComponentInChildren<Animator>();
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
  }
}