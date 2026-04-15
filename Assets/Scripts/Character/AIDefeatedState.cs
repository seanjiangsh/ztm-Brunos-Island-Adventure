using UnityEngine;

namespace RPG.Character
{
  public class AIDefeatedState : AIBaseState
  {

    public override void EnterState(EnemyController enemy)
    {
      Debug.Log($"Enemy {enemy.name} has been defeated.");
      AudioSource audioSource = enemy.GetComponent<AudioSource>();
      if (audioSource == null) return;
      
      audioSource.Play();
    }

    public override void UpdateState(EnemyController enemy)
    {

    }
  }
}