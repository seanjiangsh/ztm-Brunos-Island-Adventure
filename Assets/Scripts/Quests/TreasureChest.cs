using System;
using System.Collections.Generic;
using RPG.Utility;
using RPG.Core; 
using UnityEngine;
using UnityEngine.InputSystem;

namespace RPG.Quests
{
  public class TreasureChest : MonoBehaviour
  {
    [SerializeField] private QuestItemSO questItem;

    public Animator animatorCmp;

    private bool isInteractable = false;
    private bool hasBeenOpened = false;

    private void Start()
    {
      if (PlayerPrefs.HasKey("PlayerItems"))
      {
        List<string> playerItems = PlayerPrefsUtility.GetString("PlayerItems");
        playerItems.ForEach(CheckItem);
      }
    }

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

      EventManager.RaiseTreasureChestUnlocked(questItem, true);
      animatorCmp.SetBool(Constants.ANIMATOR_IS_SHAKING_PARAM, false);
      hasBeenOpened = true;

      AudioSource audioSource = GetComponent<AudioSource>();
      if (audioSource == null) return;
      audioSource.Play();

      // Debug.Log("Treasure Chest Opened!");
    }

    private void CheckItem(string itemName)
    {
      if (itemName != questItem.name) return;
      
      hasBeenOpened = true;
      animatorCmp.SetBool(Constants.ANIMATOR_IS_SHAKING_PARAM, false);

      EventManager.RaiseTreasureChestUnlocked(questItem);
    }
  }
}