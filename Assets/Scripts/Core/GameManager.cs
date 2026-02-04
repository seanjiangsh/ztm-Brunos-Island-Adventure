using UnityEngine;
using RPG.Character;

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
    private void HandlePortalEnter(Collider playerCollider, int sceneIndex)
    {
      PlayerController playerControllerCmp = playerCollider.GetComponent<PlayerController>();
      PlayerPrefs.SetFloat("Health", playerControllerCmp.healthCmp.healthPoints);
      PlayerPrefs.SetInt("Potions", playerControllerCmp.healthCmp.potionCount);
      PlayerPrefs.SetFloat("Damage", playerControllerCmp.combatCmp.damage);
      PlayerPrefs.SetInt("Weapon", (int)playerControllerCmp.currentWeapon);
      PlayerPrefs.SetInt("SceneIndex", sceneIndex);
    }
  }
}