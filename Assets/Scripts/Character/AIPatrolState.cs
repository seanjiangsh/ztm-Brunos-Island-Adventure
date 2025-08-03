using UnityEngine;

namespace RPG.Character
{
  public class AIPatrolState : AIBaseState
  {
    public override void EnterState(EnemyController enemy)
    {
      Debug.Log("Entering Patrol State");
    }

    public override void UpdateState(EnemyController enemy)
    {
      if (enemy.distanceFromPlayer < enemy.chaseRange)
      {
        enemy.SwitchState(enemy.chaseState);
        return;
      }
    }

    public override void ExitState(EnemyController enemy)
    {
      // Logic for exiting the patrol state, e.g., resetting variables
    }
  }
}