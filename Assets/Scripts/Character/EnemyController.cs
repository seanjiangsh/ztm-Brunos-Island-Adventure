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


    public float chaseRange = 2.5f;
    public float attackRange = 0.75f;


    private AIBaseState currentState;
    public AIReturnState returnState = new AIReturnState();
    public AIChaseState chaseState = new AIChaseState();

    private void Awake()
    {
      currentState = returnState;

      player = GameObject.FindWithTag(Constants.PLAYER_TAG);
      movementCmp = GetComponent<Movement>();

      originalPosition = transform.position;
    }

    private void Start()
    {
      currentState.EnterState(this);
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

      if (distanceFromPlayer <= chaseRange && distanceFromPlayer > attackRange)
      {
        print($"Enemy is within chase range: {distanceFromPlayer}");
        // ChasePlayer();
      }
      else if (distanceFromPlayer <= attackRange)
      {
        print($"Enemy is within attack range: {distanceFromPlayer}");
        // AttackPlayer();
      }
    }

    private void OnDrawGizmosSelected()
    {
      Gizmos.color = Color.blue;
      Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
  }
}


