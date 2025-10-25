using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

namespace RPG.UI
{
  public class UIController : MonoBehaviour
  {
    private UIDocument uiDocumentCmp;
    public VisualElement rootElement;

    public UIBaseState currentState;
    public UIMainMenuState mainMenuState;
    public List<Button> menuButtons = new();

    private void Awake()
    {
      mainMenuState = new UIMainMenuState(this);
      uiDocumentCmp = GetComponent<UIDocument>();
      rootElement = uiDocumentCmp.rootVisualElement;
    }

    // Start is called before the first frame update
    void Start()
    {
      currentState = mainMenuState;
      currentState.EnterState();
    }

    public void HandleInteract(InputAction.CallbackContext context)
    {
      if (!context.performed) return;

      currentState.SelectButton();
    }
  }
}