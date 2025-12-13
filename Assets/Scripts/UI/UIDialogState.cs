using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using Ink.Runtime;
using RPG.Utility;
using System.Collections.Generic;

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

    private bool hasChoices = false;

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
      if (hasChoices)
      {
        Button selectedChoiceButton = uiController.menuButtons[uiController.selectedButtonIndex];
        int choiceIndex = uiController.menuButtons.IndexOf(selectedChoiceButton);
        currentStory.ChooseChoiceIndex(choiceIndex);
      }

      if (!currentStory.canContinue)
      {
        ExitDialog();
        return;
      }
      
      dialogueText.text = currentStory.Continue();
      hasChoices = currentStory.currentChoices.Count > 0;

      if (hasChoices)
      {
        HandleNewChoices(currentStory.currentChoices);
      }
      else
      {
        nextButton.style.display = DisplayStyle.Flex;
        choicesGroup.style.display = DisplayStyle.None;
      }
    }

    private void HandleNewChoices(List<Choice> choices)
    {
      nextButton.style.display = DisplayStyle.None;
      choicesGroup.style.display = DisplayStyle.Flex;
      choicesGroup.Clear();
      uiController.menuButtons?.Clear();

      choices.ForEach(CreateNewChoiceButton);

      uiController.menuButtons = new List<Button>(choicesGroup.Query<Button>().ToList());
      uiController.menuButtons[0].AddToClassList("active");

      uiController.selectedButtonIndex = 0;
    }

    private void CreateNewChoiceButton(Choice choice)
    {
      Button choiceButton = new Button();
      choiceButton.AddToClassList("menu-button");
      choiceButton.text = choice.text.Trim();

      choicesGroup.Add(choiceButton);
    }

    private void ExitDialog()
    {
      dialogueContainer.style.display = DisplayStyle.None;
      playerInputCmp.SwitchCurrentActionMap(Constants.GAMEPLAY_ACTION_MAP);
    }
  }
}