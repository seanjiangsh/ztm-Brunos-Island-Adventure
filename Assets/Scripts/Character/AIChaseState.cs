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