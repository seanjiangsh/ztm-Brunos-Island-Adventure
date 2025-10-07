using UnityEngine;
using RPG.Utility;
using System;

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

    private Health healthCmp;
    public CharacterStatsSO stats;

    public float chaseRange = 2.5f;
    public float attackRange = 1.25f;


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
        return;
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
    }

    private void OnEnable()
    {
      healthCmp.OnStartDefeated += HandleStartDefeated;
    }

    private void OnDisable()
    {
      healthCmp.OnStartDefeated -= HandleStartDefeated;
    }

    private void Update()
    {
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
  }
}


