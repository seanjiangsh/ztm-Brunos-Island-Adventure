using UnityEngine;
using RPG.Utility;
using System;

namespace RPG.Character
{
  public class EmenyController : MonoBehaviour
  {
    private GameObject player;
    private Movement movementCmp;

    public float chaseRange = 2.5f;
    public float attackRange = 0.75f;
    [NonSerialized] public float distanceFromPlayer;

    private void Awake()
    {
      player = GameObject.FindWithTag(Constants.PLAYER_TAG);
      movementCmp = GetComponent<Movement>();
      print(movementCmp);
    }

    private void Update()
    {
      CalculateDistanceFromPlayer();
      ChasePlayer();
    }

    private void ChasePlayer()
    {
      if (player == null || distanceFromPlayer > chaseRange) return;

      movementCmp.MoveAgentByDestination(player.transform.position);
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


