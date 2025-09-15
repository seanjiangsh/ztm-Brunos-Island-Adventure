using UnityEngine;
using UnityEngine.InputSystem;
using RPG.Utility;
using System;

namespace RPG.Character
{
  public class Combat : MonoBehaviour
  {
    [NonSerialized] public float damage = 0f;

    private Animator animatorCmp;

    private void Awake()
    {
      animatorCmp = GetComponentInChildren<Animator>();
    }

    public void HandleAttack(InputAction.CallbackContext context)
    {
      if (!context.performed) return;

      StartAttack();
    }

    public void StartAttack()
    {
      animatorCmp.SetFloat(Constants.ANIMATOR_SPEED_PARAM, 0);
      animatorCmp.SetTrigger(Constants.ANIMATOR_IS_ATTACKING_PARAM);
    }
  }
}