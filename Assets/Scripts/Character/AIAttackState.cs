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

      // Logic for updating the attack state, e.g., performing an attack
      if (enemy.player != null)
      {
        // Here you would typically call an attack method on the player or trigger an attack animation
        Debug.Log("Attacking player at range: " + enemy.distanceFromPlayer);
      }
    }

    public override void ExitState(EnemyController enemy)
    {
      // Logic for exiting the chase state, e.g., resetting variables
    }

  }

}