namespace RPG.UI
{
  public abstract class UIBaseState
  {
    public UIController uiController;

    public UIBaseState(UIController uiController)
    {
      this.uiController = uiController;
    }

    public abstract void EnterState();

    public abstract void SelectButton();
  }
}
