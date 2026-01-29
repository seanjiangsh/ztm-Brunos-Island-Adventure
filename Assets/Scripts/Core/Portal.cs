using UnityEngine;
using RPG.Utility;

namespace RPG.Core
{
  public class Portal : MonoBehaviour
  {
    [SerializeField] private int nextSceneIndex;
    private Collider colliderCmp;

    private void Awake()
    {
      colliderCmp = GetComponent<Collider>();
    }

    // Triggered when the box collider is entered
    private void OnTriggerEnter(Collider other)
    {
      if (!other.CompareTag(Constants.PLAYER_TAG))return;
      
      colliderCmp.enabled = false;
      EventManager.RaisePortalEnter(colliderCmp, nextSceneIndex);
      SceneTranstion.Initiate(nextSceneIndex);
    }
  }
}