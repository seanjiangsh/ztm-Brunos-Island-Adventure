using UnityEngine;
using UnityEngine.UIElements;

namespace RPG.UI
{
  public class UIController : MonoBehaviour
  {
    private UIDocument uiDocumentCmp;
    private VisualElement rootElement;

    public UIBaseState currentState;
    public UIMainMenuState mainMenuState;

    private void Awake()
    {
      mainMenuState = new UIMainMenuState(this);
      uiDocumentCmp = GetComponent<UIDocument>();
      rootElement = uiDocumentCmp.rootVisualElement;
    }

    // Start is called before the first frame update
    void Start()
    {
      currentState = mainMenuState;
      currentState.EnterState();
    }
  }
}