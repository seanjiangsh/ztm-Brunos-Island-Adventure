using UnityEngine;

namespace RPG.Character
{
  public class AIChaseState : AIBaseState
  {
    public override void EnterState(EnemyController enemy)
    {
      // Logic for entering the chase state, e.g., setting a destination
      enemy.movementCmp.UpdateAgentSpeed(enemy.stats.runSpeed);
      enemy.movementCmp.MoveAgentByDestination(enemy.player.transform.position);
    }

    public override void UpdateState(EnemyController enemy)
    {
      float dist = enemy.distanceFromPlayer;
      float attackRange = enemy.attackRange;
      float chaseRange = enemy.chaseRange;
      GameObject player = enemy.player;
      Movement move = enemy.movementCmp;

      if (dist < attackRange)
      {
        enemy.SwitchState(enemy.attackState);
        return;
      }
      else if (dist > chaseRange)
      {
        enemy.SwitchState(enemy.returnState);
        return;
      }

      // Chase logic
      // Pattern match: only runs if player is not null
      if (enemy.player is { transform: var playerTransform })
      {
        Vector3 playerPos = playerTransform.position;
        Vector3 enemyPos = enemy.transform.position;
        Vector3 playerDirection = playerPos - enemyPos;

        move.MoveAgentByDestination(playerPos);
        move.Rotate(playerDirection);
      }
    }


    public override void ExitState(EnemyController enemy)
    {
      // Logic for exiting the chase state, e.g., resetting variables
    }

  }

}