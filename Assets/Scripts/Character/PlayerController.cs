using UnityEngine;
using RPG.Utility;
using System;


namespace RPG.Character
{
  public class PlayerController : MonoBehaviour
  {
    public CharacterStatsSO stats;

    private void Awake()
    {
      if (stats == null)
      {
        Debug.LogError($"CharacterStatsSO is not assigned in PlayerController {name}.");
        return;
      }

      // Initialize player components and states here
    }
  }

}