using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using Ink.Runtime;
using RPG.Utility;

namespace RPG.UI
{
  [RequireComponent(typeof(UIDocument))]
  public class UIDialogueState : UIBaseState
  {
    private VisualElement dialogueContainer;
    private Label dialogueText;
    private VisualElement nextButton;
    private VisualElement choicesGroup;
    private Story currentStory;
    private PlayerInput playerInputCmp;

    public UIDialogueState(UIController uiController) : base(uiController) { }

    public override void EnterState()
    {
      dialogueContainer = uiController.rootElement.Q<VisualElement>("dialog-container");
      dialogueText = dialogueContainer.Q<Label>("dialog-text");
      nextButton = dialogueContainer.Q<VisualElement>("dialog-next-button");
      choicesGroup = dialogueContainer.Q<VisualElement>("choices-group");
      dialogueContainer.style.display = DisplayStyle.Flex;

      playerInputCmp = GameObject.FindGameObjectWithTag(Constants.GAME_MANAGER_TAG).GetComponent<PlayerInput>();
      playerInputCmp.SwitchCurrentActionMap(Constants.UI_ACTION_MAP);
    }

    public override void SelectButton()
    {
      UpdateDialogue(); 
    }

    public void SetStory(TextAsset inkJSONAsset)
    {
      currentStory = new Story(inkJSONAsset.text);
      UpdateDialogue();
    }

    public void UpdateDialogue()
    {
      dialogueText.text = currentStory.Continue();
    }
  }
}