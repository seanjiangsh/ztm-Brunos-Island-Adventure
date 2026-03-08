using UnityEngine;

namespace RPG.Core
{
  public class CinematicController : MonoBehaviour
  {
    private void OnTriggerEnter(Collider other)
    {
      Debug.Log($"CinematicController triggered by {other.name}");
    }
  }
}