using UnityEngine;

namespace RPG.Character
{
  public class AIDefeatedState : AIBaseState
  {

    public override void EnterState(EnemyController enemy)
    {
      AudioSource audioSource = enemy.GetComponent<AudioSource>();
      if (audioSource == null) return;
      
      audioSource.Play();
    }

    public override void UpdateState(EnemyController enemy)
    {

    }
  }
}