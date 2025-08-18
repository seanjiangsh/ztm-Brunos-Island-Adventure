using UnityEngine;
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
      if (isAtDestination)
      {
        if (enemy.patrolCmp != null)
        {
          enemy.SwitchState(enemy.patrolState);
          return;
        }
      }
      else
      {
        if (enemy.patrolCmp != null)
        {
          Vector3 currentPos = enemy.transform.position;
          Vector3 newForwardPos = targetPosition - currentPos;
          newForwardPos.y = 0; // Ensure we are only rotating on the horizontal plane
          enemy.movementCmp.Rotate(newForwardPos);
        }
        else
        {
          Vector3 originalPos = enemy.originalPosition;
          Vector3 currentPos = enemy.transform.position;
          Vector3 newForwardPos = originalPos - currentPos;
          newForwardPos.y = 0; // Ensure we are only rotating on the horizontal plane
          enemy.movementCmp.Rotate(newForwardPos);
        }
      }
    }

    public override void ExitState(EnemyController enemy)
    {
      // 
    }
  }
}