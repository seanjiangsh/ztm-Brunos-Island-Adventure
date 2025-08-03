using UnityEngine;


namespace RPG.Character
{
  public class AIReturnState : AIBaseState
  {
    Vector3 targetPosition;

    public override void EnterState(EnemyController enemy)
    {

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

      if (enemy.patrolCmp != null && enemy.movementCmp.ReachedDestination())
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