using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using RPG.Core;

namespace RPG.UI
{
  [RequireComponent(typeof(UIDocument))]
  public class UIController : MonoBehaviour
  {
    private UIDocument uiDocumentCmp;
    public VisualElement rootElement;
    public VisualElement mainMenuElement;
    public VisualElement playerInfoElement;
    public Label healthLabel;
    public Label potionsLabel;

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
      healthLabel = playerInfoElement.Q<Label>("health-label");
      potionsLabel = playerInfoElement.Q<Label>("potions-label");

      mainMenuState = new UIMainMenuState(this);
    }

    void OnEnable()
    {
      EventManager.OnChangePlayerHealth += HandlePlayerHealthChange;
      EventManager.OnChangePlayerPotion += HandlePotionCountChange;
    }

    // Start is called before the first frame update
    void Start()
    {
      int sceneIndex = SceneManager.GetActiveScene().buildIndex;
      // Debug.Log("Current Scene Index: " + sceneIndex);
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

    void OnDisable()
    {
      EventManager.OnChangePlayerHealth -= HandlePlayerHealthChange;
      EventManager.OnChangePlayerPotion -= HandlePotionCountChange;
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

    private void HandlePlayerHealthChange(float newHealthPoints)
    {
      healthLabel.text = newHealthPoints.ToString();
    }

    private void HandlePotionCountChange(int newPotionCount)
    {
      potionsLabel.text = newPotionCount.ToString();
    }
  }
}