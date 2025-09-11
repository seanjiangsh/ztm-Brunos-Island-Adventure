using UnityEngine;

namespace RPG.Character
{
  public class AIPatrolState : AIBaseState
  {
    public override void EnterState(EnemyController enemy)
    {
      // enemy.patrolCmp.ResetTimers();
    }

    public override void UpdateState(EnemyController enemy)
    {
      if (enemy.distanceFromPlayer < enemy.chaseRange)
      {
        enemy.SwitchState(enemy.chaseState);
        return;
      }
      Vector3 oldPosition = enemy.patrolCmp.GetNextPosition();

      // * Calculate the next position in the patrol route
      enemy.patrolCmp.CalculateNextPosition();

      Vector3 currentPosition = enemy.transform.position;
      Vector3 nextPosition = enemy.patrolCmp.GetNextPosition();
      Vector3 offset = nextPosition - currentPosition;

      enemy.movementCmp.MoveAgentByOffset(offset);

      Vector3 fartherOutPosition = enemy.patrolCmp.GetFartherOutPosition();
      Vector3 newFacingDirection = fartherOutPosition - currentPosition;
      newFacingDirection.y = 0; // Ensure we are only rotating on the horizontal plane
      enemy.movementCmp.Rotate(newFacingDirection);

      // * Check if we've reached the patrol point (enemy is paused)
      if (oldPosition == nextPosition)
      {
        enemy.movementCmp.isMoving = false;
      }
    }

    public override void ExitState(EnemyController enemy)
    {
      // Logic for exiting the patrol state, e.g., resetting variables
    }
  }
}