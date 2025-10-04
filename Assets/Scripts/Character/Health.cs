using UnityEngine;
using System;
using RPG.Utility;

namespace RPG.Character
{
  public class Health : MonoBehaviour
  {
    [NonSerialized] public float healthPoints = 0f;

    private Animator animatorCmp;

    private void Awake()
    {
      animatorCmp = GetComponentInChildren<Animator>();
    }

    public void TakeDamage(float damage)
    {
      healthPoints = Mathf.Max(healthPoints - damage, 0);

      if (healthPoints <= 0)
      {
        Defeated();
      }
    }

    private void Defeated()
    {
      animatorCmp.SetTrigger(Constants.ANIMATOR_IS_DEFEATED_PARAM);
    }
  }
}