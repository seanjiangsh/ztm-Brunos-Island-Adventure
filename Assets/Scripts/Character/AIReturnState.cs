using UnityEngine;


namespace RPG.Character
{
  public class AIReturnState : AIBaseState
  {
    Vector3 targetPosition;

    public override void EnterState(EnemyController enemy)
    {
      enemy.movementCmp.UpdateAgentSpeed(enemy.stats.walkSpeed);

      if (enemy.patrolCmp != null)
      {
        targetPosition = enemy.patrolCmp.GetNextPosition();
        enemy.movementCmp.MoveAgentByDestination(targetPosition);
      }
      else
      {
        // Logic for entering the return state, e.g., setting a destination
        enemy.movementCmp.MoveAgentByDestination(enemy.originalPosition);
      }
    }

    public override void UpdateState(EnemyController enemy)
    {
      if (enemy.distanceFromPlayer < enemy.chaseRange)
      {
        enemy.SwitchState(enemy.chaseState);
        return;
      }

      bool isAtDestination = enemy.movementCmp.ReachedDestination();
      if (enemy.patrolCmp != null && isAtDestination)
      {
        enemy.SwitchState(enemy.patrolState);
        return;
      }
    }

    public override void ExitState(EnemyController enemy)
    {
      // 
    }
  }
}