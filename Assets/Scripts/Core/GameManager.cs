using UnityEngine;

namespace RPG.Core
{
  public class GameManager:MonoBehaviour
  {
    private void OnEnable()
    {
      EventManager.OnPortalEnter += HandlePortalEnter;
    }

    private void OnDisable()
    {
      EventManager.OnPortalEnter -= HandlePortalEnter;
    }
    private void HandlePortalEnter(Collider portalCollider, int sceneIndex)
    {
      // Handle portal enter logic here
      Debug.Log($"Player entered portal to scene {sceneIndex}");
    }
  }
}