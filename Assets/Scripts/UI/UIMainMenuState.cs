using UnityEngine;
using UnityEngine.UIElements;
using RPG.Core;

namespace RPG.UI
{
  public class UIMainMenuState : UIBaseState
  {
    public UIMainMenuState(UIController uiController) : base(uiController) { }

    public override void EnterState()
    {
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
        SceneTranstion.Initiate(1); // Load the game scene
      }
    }
  }
}