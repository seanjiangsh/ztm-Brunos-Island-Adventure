using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using RPG.Utility;
using RPG.Core;

namespace RPG.UI
{
  public class UIGameOverState : UIBaseState
  {
    public UIGameOverState(UIController uiController) : base(uiController) { }

    public override void EnterState()
    {
      PlayerInput playerInputCmp = GameObject.FindGameObjectWithTag(
        Constants.GAME_MANAGER_TAG
      ).GetComponent<PlayerInput>();

      VisualElement gameOverContainer = uiController.rootElement
        .Q<VisualElement>("game-over-container");

      playerInputCmp.SwitchCurrentActionMap(
        Constants.UI_ACTION_MAP
      );
      gameOverContainer.style.display = DisplayStyle.Flex;

      uiController.audioSourceCmp.clip = uiController.gameOverAudio;
      uiController.audioSourceCmp.PlayOneShot(uiController.gameOverAudio);
      uiController.canPause = false;
    }

    public override void SelectButton()
    {
      PlayerPrefs.DeleteAll();
      uiController.StartCoroutine(SceneTranstion.Initiate(0));
    }
  }
}