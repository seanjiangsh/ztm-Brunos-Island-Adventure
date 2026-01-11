using UnityEngine;
using RPG.Character;

namespace RPG.Quests
{
  [CreateAssetMenu(
    fileName = "New Reward",
    menuName = "Quests/Reward",
    order = 2 
  )]
  public class RewardSO: ScriptableObject
  {
    public float bonusHealth = 0f;
    public float bonusDamage = 0f;
    public int bonusPotions = 0;
    public bool forceWeaponSwap = false;
    public Weapons weapons = Weapons.Sword;
  }
}