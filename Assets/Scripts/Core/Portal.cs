using UnityEngine;
using RPG.Utility;

namespace RPG.Core
{
  public class Portal : MonoBehaviour
  {
    [SerializeField] private string targetSceneName;
    [SerializeField] private Transform spawnPoint;

    // Triggered when the box collider is entered
    private void OnTriggerEnter(Collider other)
    {
      if (!other.CompareTag(Constants.PLAYER_TAG))return;
      
      Debug.Log($"Player entered portal to {targetSceneName}.");
    }
  }
}