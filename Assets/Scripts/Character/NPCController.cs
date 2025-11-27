using UnityEngine;
using UnityEngine.InputSystem;

namespace RPG.Character
{
  public class NPCController : MonoBehaviour
  {
    public TextAsset inkJSONAsset;
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

      Debug.Log("Interacted with NPC: " + gameObject.name);
    }
  }
}