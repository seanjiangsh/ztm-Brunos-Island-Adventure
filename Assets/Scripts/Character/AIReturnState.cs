using UnityEngine;

namespace RPG.Character
{
  public class AIReturnState : AIBaseState
  {
    public override void EnterState(EnemyController enemy)
    {
      // Logic for entering the return state
      Debug.Log("Entering Return State");
    }

    public override void UpdateState(EnemyController enemy)
    {
      // 
    }

    public override void ExitState(EnemyController enemy)
    {
      // 
    }
  }
}