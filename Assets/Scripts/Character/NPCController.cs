using UnityEngine;
using UnityEngine.InputSystem;
using RPG.Core;
using RPG.Quests;

namespace RPG.Character
{
  public class NPCController : MonoBehaviour
  {
    public TextAsset inkJSONAsset;
    public QuestItemSO desiredQuestItem;
    private bool hasQuestItem = false;
    private Canvas canvasCmp;

    private void Awake()
    {
      canvasCmp = GetComponentInChildren<Canvas>();
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
      return hasQuestItem;
    }
  }
}