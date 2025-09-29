using UnityEngine;

namespace RPG.Character
{
  public class AIAttackState : AIBaseState
  {
    public override void EnterState(EnemyController enemy)
    {
      enemy.movementCmp.StopMovingAgent();
    }

    public override void UpdateState(EnemyController enemy)
    {
      if (enemy.distanceFromPlayer > enemy.attackRange)
      {
        enemy.SwitchState(enemy.chaseState);
        return;
      }

      enemy.combatCmp.StartAttack();
    }

    public override void ExitState(EnemyController enemy)
    {
      // Logic for exiting the chase state, e.g., resetting variables
    }

  }

}