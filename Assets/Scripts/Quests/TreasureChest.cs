using UnityEngine;
using UnityEngine.InputSystem;

namespace RPG.Quests
{
  public class TreasureChest : MonoBehaviour
  {
    private bool isInteractable = false;
    private bool hasBeenOpened = false;

    private void OnTriggerEnter(Collider other)
    {
      isInteractable = true;
      Debug.Log("Player entered the treasure chest area!");
    }

    private void OnTriggerExit(Collider other)
    {
      isInteractable = false;
      Debug.Log("Player exited the treasure chest area!");
    }


    public void HandleInteract(InputAction.CallbackContext context)
    {
      Debug.Log($"Interact action triggered. IsInteractable: {isInteractable}, HasBeenOpened: {hasBeenOpened}");

      if (!isInteractable || hasBeenOpened) return;

      hasBeenOpened = true;
      Debug.Log("Treasure chest opened!");
    }
  }
}