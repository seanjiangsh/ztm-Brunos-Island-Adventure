using UnityEngine;

namespace RPG.Quests
{
  public class RewardSO: ScriptableObject
  {
    public float bonusHealth = 0f;
    public float bonusDamage = 0f;
    public int bonusPoints = 0;
    public bool forceWeaponSwap = false;
  }
}