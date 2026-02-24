using System.Collections.Generic;
using UnityEngine;
using RPG.Character;
using RPG.Utility;
using RPG.Quests;

namespace RPG.Core
{
  public class GameManager:MonoBehaviour
  {
    private List<string> sceneEnemyIDs = new();
    private List<GameObject> enemiesAlive = new();

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

      enemiesAlive.AddRange(GameObject.FindGameObjectsWithTag(Constants.ENEMY_TAG));
      sceneEnemyIDs.ForEach(SaveDefeatedEnemies);

      Inventory inventoryCmp = playerControllerCmp.GetComponent<Inventory>();
      inventoryCmp.items.ForEach(SaveQuestItem);

      GameObject[] NPCObjects = GameObject.FindGameObjectsWithTag(Constants.NPC_QUEST_TAG);
      List<GameObject> NPCsWithQuests = new(NPCObjects);
      NPCsWithQuests.ForEach(SaveNPCQuestItem);
    }

    private void SaveDefeatedEnemies(string enemyID)
    {
      bool isEnemyAlive = false;
      
      enemiesAlive.ForEach(enemy =>
      {
        if (enemy.TryGetComponent<EnemyController>(out var enemyControllerCmp))
        {
          if (enemyControllerCmp.ID == enemyID)
          {
            isEnemyAlive = true;
          }
        }
      });

      if (isEnemyAlive) return;

      List<string> defeatedEnemies = PlayerPrefsUtility.GetString("DefeatedEnemies");
      defeatedEnemies.Add(enemyID);

      PlayerPrefsUtility.SetString("DefeatedEnemies", defeatedEnemies);
    }

    private void SaveQuestItem(QuestItemSO item)
    {
      List<string> playerItems = PlayerPrefsUtility.GetString("PlayerItems");
      playerItems.Add(item.name);
      PlayerPrefsUtility.SetString("PlayerItems", playerItems);
    }

    private void SaveNPCQuestItem(GameObject npc)
    {
      NPCController npcControllerCmp = npc.GetComponent<NPCController>();
      if (npcControllerCmp == null) return;

      List <string> npcQuestItems = PlayerPrefsUtility.GetString("NPCItems");
      npcQuestItems.Add(npcControllerCmp.desiredQuestItem.itemName);
      PlayerPrefsUtility.SetString("NPCItems", npcQuestItems);
    }
  }
}