using RPG.Utility;
using RPG.Core; 
using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace RPG.Quests
{
  public class TreasureChest : MonoBehaviour
  {
    [SerializeField] private QuestItemSO questItem;

    public Animator animatorCmp;

    private bool isInteractable = false;
    private bool hasBeenOpened = false;

    private void OnTriggerEnter(Collider other)
    {
      isInteractable = true;
    }

    private void OnTriggerExit(Collider other)
    {
      isInteractable = false;
    }


    public void HandleInteract(InputAction.CallbackContext context)
    {
      if (!isInteractable || hasBeenOpened || !context.performed) return;

      EventManager.RaiseTreasureChestUnlocked(questItem);
      animatorCmp.SetBool(Constants.ANIMATOR_IS_SHAKING_PARAM, false);
      hasBeenOpened = true;
      Debug.Log("Treasure Chest Opened!");
    }
  }
}