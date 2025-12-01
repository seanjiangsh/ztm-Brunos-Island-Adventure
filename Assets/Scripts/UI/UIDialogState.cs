using UnityEngine;
using UnityEngine.UIElements;

namespace RPG.UI
{
  [RequireComponent(typeof(UIDocument))]
  public class UIDialogueState : UIBaseState
  {
    private VisualElement dialogueContainer;
    private Label dialogueText;
    private VisualElement nextButton;
    private VisualElement choicesGroup;

    public UIDialogueState(UIController uiController) : base(uiController) { }

    public override void EnterState()
    {
      dialogueContainer = uiController.rootElement.Q<VisualElement>("dialog-container");
      dialogueText = dialogueContainer.Q<Label>("dialog-text");
      nextButton = dialogueContainer.Q<VisualElement>("dialog-next-button");
      choicesGroup = dialogueContainer.Q<VisualElement>("choices-group");
      dialogueContainer.style.display = DisplayStyle.Flex;
    }

    public override void SelectButton() { }
  }
}