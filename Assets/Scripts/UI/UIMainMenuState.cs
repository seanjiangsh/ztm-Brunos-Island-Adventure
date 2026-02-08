using UnityEngine;
using UnityEngine.UIElements;
using RPG.Core;

namespace RPG.UI
{
  public class UIMainMenuState : UIBaseState
  {
    private int sceneIndex;

    public UIMainMenuState(UIController uiController) : base(uiController) { }

    public override void EnterState()
    {
      if (PlayerPrefs.HasKey("SceneIndex"))
      {
        sceneIndex = PlayerPrefs.GetInt("SceneIndex");
        AddButton();
      }

      uiController.mainMenuElement.style.display = DisplayStyle.Flex;

      uiController.menuButtons = uiController.mainMenuElement
        .Query<Button>(null, "menu-button")
        .ToList();

      uiController.menuButtons[0].AddToClassList("active");
    }

    public override void SelectButton()
    {
      int selectedBtnIndex = uiController.selectedButtonIndex;
      Button button = uiController.menuButtons[selectedBtnIndex];

      if (button.name == "start-button")
      {
        PlayerPrefs.DeleteAll(); // Clear saved data for a new game
        SceneTranstion.Initiate(1); // Load the game scene
      }
      else
      {
        SceneTranstion.Initiate(sceneIndex); // Load the saved scene
      }
    }

    private void AddButton()
    {
      Button continueButton = new()
      {
        name = "continue-button",
        text = "Continue"
      };
      continueButton.AddToClassList("menu-button");

      VisualElement mainMenuButtons = uiController.mainMenuElement.Q<VisualElement>("buttons");
      mainMenuButtons.Add(continueButton);
    }
  }
}