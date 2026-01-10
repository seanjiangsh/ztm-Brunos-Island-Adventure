using UnityEngine;
using UnityEngine.InputSystem;
using RPG.Core;
using RPG.Quests;
using RPG.Utility;

namespace RPG.Character
{
  public class NPCController : MonoBehaviour
  {
    public TextAsset inkJSONAsset;
    public QuestItemSO desiredQuestItem;
    public bool hasQuestItem = false;
    private Canvas canvasCmp;
    private Reward rewardCmp;

    private void Awake()
    {
      canvasCmp = GetComponentInChildren<Canvas>();
      rewardCmp = GetComponent<Reward>();
    }

    private void OnTriggerEnter()
    {
      canvasCmp.enabled = true;
    }

    private void OnTriggerExit()
    {
      canvasCmp.enabled = false;
    }

    public void HandleInteract(InputAction.CallbackContext context)
    {
      if (!context.performed || !canvasCmp.enabled) return;

      if (inkJSONAsset == null)
      {
        Debug.LogError($"Ink JSON Asset is not assigned in NPCController {name}.");
        return;
      }

      EventManager.RaiseInitiateDialogue(inkJSONAsset, gameObject);
    }

    public bool CheckPlayerQuestItem()
    {
      if (hasQuestItem) return true;

      Inventory playerInventory = GameObject
        .FindGameObjectWithTag(Constants.PLAYER_TAG)
        .GetComponent<Inventory>();
      
      hasQuestItem = playerInventory.HasItem(desiredQuestItem);

      if (hasQuestItem && rewardCmp != null)
      {
        rewardCmp.GrantReward();
      }
      
      return hasQuestItem;
    }
  }
}