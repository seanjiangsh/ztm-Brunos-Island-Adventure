using UnityEngine;

namespace RPG.Quests
{
  public class TreasureChest : MonoBehaviour
  {
    private void OnTriggerEnter(Collider other)
    {
      Debug.Log("Player entered the treasure chest area!");
    }

  }
}