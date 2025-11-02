using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace RPG.UI
{
  public class UIController : MonoBehaviour
  {
    private UIDocument uiDocumentCmp;
    public VisualElement rootElement;
    public VisualElement mainMenuElement;
    public VisualElement playerInfoElement;

    public UIBaseState currentState;
    public UIMainMenuState mainMenuState;
    public List<Button> menuButtons = new();
    public int selectedButtonIndex = 0;

    private void Awake()
    {
      uiDocumentCmp = GetComponent<UIDocument>();
      rootElement = uiDocumentCmp.rootVisualElement;

      mainMenuElement = rootElement.Q<VisualElement>("main-menu-container");
      playerInfoElement = rootElement.Q<VisualElement>("player-info-container");

      mainMenuState = new UIMainMenuState(this);
    }

    // Start is called before the first frame update
    void Start()
    {
      int sceneIndex = SceneManager.GetActiveScene().buildIndex;
      Debug.Log("Current Scene Index: " + sceneIndex);
      if (sceneIndex == 0)
      {
        currentState = mainMenuState;
        currentState.EnterState();
      }
      else
      {
        playerInfoElement.style.display = DisplayStyle.Flex;
      }
    }

    public void HandleInteract(InputAction.CallbackContext context)
    {
      if (!context.performed) return;

      currentState.SelectButton();
    }

    public void HandleNavigate(InputAction.CallbackContext context)
    {
      if (!context.performed || menuButtons.Count == 0) return;

      menuButtons[selectedButtonIndex].RemoveFromClassList("active");

      Vector2 navigationInput = context.ReadValue<Vector2>();
      selectedButtonIndex += navigationInput.x > 0 ? 1 : -1;
      selectedButtonIndex = Mathf.Clamp(selectedButtonIndex, 0, menuButtons.Count - 1);
      menuButtons[selectedButtonIndex].AddToClassList("active");
    }
  }
}