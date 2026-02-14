using System.Collections.Generic;
using UnityEngine;
using RPG.Character;
using RPG.Utility;

namespace RPG.Core
{
  public class GameManager:MonoBehaviour
  {
    private List<string> sceneEnemyIDs = new();

    private void Start()
    {
      GameObject[] enemies = GameObject.FindGameObjectsWithTag(Constants.ENEMY_TAG);
      List<GameObject> enemiesInScene = new();
      enemiesInScene.AddRange(enemies);
      enemiesInScene.ForEach(enemy =>
      {
        if (enemy.TryGetComponent<EnemyController>(out var enemyControllerCmp))
        {
          sceneEnemyIDs.Add(enemyControllerCmp.ID);
        }
        else
        {
          Debug.LogWarning($"GameObject {enemy.name} tagged as Enemy does not have an EnemyController component.");
        }
      });
    }
    
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