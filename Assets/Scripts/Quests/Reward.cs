using UnityEngine;
using RPG.Core;

namespace RPG.Quests
{
  public class Reward: MonoBehaviour
  {
    [SerializeField] private RewardSO reward;   
    private bool rewardTaken = false;

    public void GrantReward()
    {
      if (rewardTaken) return;
      EventManager.RaiseApplyReward(reward);
      rewardTaken = true;
    }
  }
}
