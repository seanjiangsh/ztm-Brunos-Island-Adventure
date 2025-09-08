using RPG.Utility;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RPG.Quests
{
  public class TreasureChest : MonoBehaviour
  {
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
      if (!isInteractable || hasBeenOpened) return;

      animatorCmp.SetBool(Constants.ANIMATOR_IS_SHAKING_PARAM, false);
      hasBeenOpened = true;
      Debug.Log("Treasure Chest Opened!");
    }
  }
}