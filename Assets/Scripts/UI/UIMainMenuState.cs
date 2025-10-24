using UnityEngine;
using UnityEngine.UIElements;

namespace RPG.UI
{
  public class UIMainMenuState : UIBaseState
  {
    public UIMainMenuState(UIController uiController) : base(uiController)
    {

    }

    public override void EnterState()
    {
      uiController.menuButtons = uiController.rootElement
        .Query<Button>(null, "menu-button")
        .ToList();
    }

    public override void SelectButton()
    {

    }
  }
}