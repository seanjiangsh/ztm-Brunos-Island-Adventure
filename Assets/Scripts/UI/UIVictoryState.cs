using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using RPG.Utility;
using RPG.Core;

namespace RPG.UI
{
  public class UIVictoryState : UIBaseState
  {
    public UIVictoryState(UIController uiController) : base(uiController) { }

    public override void EnterState()
    {
      PlayerInput playerInputCmp = GameObject.FindGameObjectWithTag(
        Constants.GAME_MANAGER_TAG
      ).GetComponent<PlayerInput>();
      VisualElement victoryContainer = uiController.rootElement
        .Q<VisualElement>("victory-container");

      playerInputCmp.SwitchCurrentActionMap(Constants.UI_ACTION_MAP);
      victoryContainer.style.display = DisplayStyle.Flex;

      uiController.audioSourceCmp.clip = uiController.victoryAudio;
      uiController.audioSourceCmp.Play();
    }

    public override void SelectButton()
    {
      PlayerPrefs.DeleteAll();
      uiController.StartCoroutine(SceneTranstion.Initiate(0));
    }
  }
}