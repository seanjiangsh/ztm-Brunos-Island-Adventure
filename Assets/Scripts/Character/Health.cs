using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System;
using RPG.Utility;
using RPG.Core;

namespace RPG.Character
{
  public class Health : MonoBehaviour
  {
    [NonSerialized] public float healthPoints = 0f;
    [NonSerialized] public Slider healthBarCmp;
    [SerializeField] public int potionCount = 1;

    [SerializeField] private float healAmount = 15f;

    public event UnityAction OnStartDefeated = () => { };

    private bool isDefeated = false;
    private Animator animatorCmp;
    private BubbleEvent bubbleEventCmp;


    private void Awake()
    {
      animatorCmp = GetComponentInChildren<Animator>();
      healthBarCmp = GetComponentInChildren<Slider>();
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

      if (CompareTag(Constants.PLAYER_TAG))
      {
        EventManager.RaiseChangePlayerHealth(healthPoints);
      }

      if (healthBarCmp != null)
      {
        healthBarCmp.value = healthPoints;
      }

      if (healthPoints <= 0 && !isDefeated)
      {
        Defeated();
      }
    }

    private void Defeated()
    {
      if (isDefeated) return;

      if (CompareTag(Constants.ENEMY_TAG))
      {
        OnStartDefeated.Invoke();
      }



      animatorCmp.SetTrigger(Constants.ANIMATOR_IS_DEFEATED_PARAM);
      isDefeated = true;
    }

    private void HandleBubbleCompleteDefeat()
    {
      Destroy(gameObject);
    }

    public void HandleHeal(InputAction.CallbackContext context)
    {
      if (!context.performed || potionCount == 0) return;

      potionCount--;
      healthPoints += healAmount;

      EventManager.RaiseChangePlayerHealth(healthPoints);
      EventManager.RaiseChangePlayerPotion(potionCount);
    }
  }
}