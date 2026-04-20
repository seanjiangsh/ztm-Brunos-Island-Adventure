using UnityEngine;
using System;
using System.Collections.Generic;
using RPG.Utility;
using RPG.Core;

namespace RPG.Character
{
  public class EnemyController : MonoBehaviour
  {
    // NonSerialized attribute is used to prevent serialization of these fields in Unity's inspector
    [NonSerialized] public GameObject player;
    [NonSerialized] public float distanceFromPlayer;
    [NonSerialized] public Vector3 originalPosition;
    [NonSerialized] public Movement movementCmp;
    [NonSerialized] public Patrol patrolCmp;
    [NonSerialized] public Combat combatCmp;
    [NonSerialized] public bool HasUIOpened;

    private Health healthCmp;
    public CharacterStatsSO stats;

    public float chaseRange = 2.5f;
    public float attackRange = 1.25f;
    public string ID = "";


    private AIBaseState currentState;
    public AIReturnState returnState = new();
    public AIChaseState chaseState = new();
    public AIAttackState attackState = new();
    public AIPatrolState patrolState = new();
    public AIDefeatedState defeatedState = new();

    private void Awake()
    {
      if (stats == null)
      {
        Debug.LogError($"CharacterStatsSO is not assigned in EnemyController {name}.");
        enabled = false;
        return;
      }

      if (string.IsNullOrEmpty(ID))
      {
        Debug.LogWarning($"EnemyController {name} has an empty ID. Consider assigning a unique ID for better debugging and tracking.");
      }

      currentState = returnState;

      player = GameObject.FindWithTag(Constants.PLAYER_TAG);
      movementCmp = GetComponent<Movement>();
      patrolCmp = GetComponent<Patrol>();
      healthCmp = GetComponent<Health>();
      combatCmp = GetComponent<Combat>();

      originalPosition = transform.position;
    }

    private void Start()
    {
      currentState.EnterState(this);

      healthCmp.healthPoints = stats.health;
      combatCmp.damage = stats.damage;

      if (healthCmp.healthBarCmp != null)
      {
        healthCmp.healthBarCmp.maxValue = stats.health;
        healthCmp.healthBarCmp.value = stats.health;
      }

      List<string> defeatedEnemies = PlayerPrefsUtility.GetString("DefeatedEnemies");
      defeatedEnemies.ForEach(defeatedEnemyID =>
      {
        if (defeatedEnemyID == ID)
        {
          Destroy(gameObject);
        }
      });
    }

    private void OnEnable()
    {
      if (healthCmp != null)
      {
        healthCmp.OnStartDefeated += HandleStartDefeated;
      }
      EventManager.OnToggleUI += HandleToggleUI;
    }

    private void OnDisable()
    {
      if (healthCmp != null)
      {
        healthCmp.OnStartDefeated -= HandleStartDefeated;
      }
      EventManager.OnToggleUI -= HandleToggleUI;
    }

    private void Update()
    {
      if (currentState == null)
      {
        return;
      }

      CalculateDistanceFromPlayer();
      currentState.UpdateState(this);
    }

    public void SwitchState(AIBaseState newState)
    {
      currentState = newState;
      currentState.EnterState(this);
    }

    private void CalculateDistanceFromPlayer()
    {
      if (player == null) return;

      Vector3 enemyPosition = transform.position;
      Vector3 playerPosition = player.transform.position;
      distanceFromPlayer = Vector3.Distance(enemyPosition, playerPosition);
    }

    private void OnDrawGizmosSelected()
    {
      Gizmos.color = Color.blue;
      Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    private void HandleStartDefeated()
    {
      SwitchState(defeatedState);
      currentState.EnterState(this);
    }

    private void HandleToggleUI(bool isUIOpened)
    {
      HasUIOpened = isUIOpened;
    }
  }
}


