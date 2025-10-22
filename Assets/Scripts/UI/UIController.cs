using UnityEngine;

namespace RPG.UI
{
  public class UIController : MonoBehaviour
  {
    public UIBaseState currentState;
    public UIMainMenuState mainMenuState;

    private void Awake()
    {
      mainMenuState = new UIMainMenuState(this);
    }

    // Start is called before the first frame update
    void Start()
    {
      currentState = mainMenuState;
      currentState.EnterState();
    }
  }
}