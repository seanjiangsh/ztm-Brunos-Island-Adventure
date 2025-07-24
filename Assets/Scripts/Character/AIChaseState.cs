using UnityEngine;

namespace RPG.Character
{
  public class AIChaseState : AIBaseState
  {
    public override void EnterState(EnemyController enemy)
    {
      // Logic for entering the chase state, e.g., setting a destination
      enemy.movementCmp.MoveAgentByDestination(enemy.player.transform.position);
    }

    public override void UpdateState(EnemyController enemy)
    {
      if (enemy.distanceFromPlayer < enemy.attackRange)
      {
        enemy.SwitchState(enemy.attackState);
        return;
      }
      else if (enemy.distanceFromPlayer > enemy.chaseRange)
      {
        enemy.SwitchState(enemy.returnState);
        return;
      }

      // Logic for updating the chase state, e.g., moving towards the player
      if (enemy.player != null)
      {
        enemy.movementCmp.MoveAgentByDestination(enemy.player.transform.position);
      }
    }

    public override void ExitState(EnemyController enemy)
    {
      // Logic for exiting the chase state, e.g., resetting variables
    }

  }

}