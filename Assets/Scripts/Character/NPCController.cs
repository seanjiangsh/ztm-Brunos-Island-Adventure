using UnityEngine;
using UnityEngine.InputSystem;

namespace RPG.Character
{
  public class NPCController : MonoBehaviour
  {
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
      Debug.Log("Interacted with NPC: " + gameObject.name);
    }
  }
}