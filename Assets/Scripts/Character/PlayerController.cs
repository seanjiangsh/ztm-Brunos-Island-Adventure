using UnityEngine;
using RPG.Utility;
using System;


namespace RPG.Character
{
  public class PlayerController : MonoBehaviour
  {
    private Health healthCmp;
    private Combat combatCmp;

    public CharacterStatsSO stats;

    private void Awake()
    {
      if (stats == null)
      {
        Debug.LogError($"CharacterStatsSO is not assigned in PlayerController {name}.");
        return;
      }

      // Initialize player components and states here
      healthCmp = GetComponent<Health>();
      combatCmp = GetComponent<Combat>();
    }

    private void Start()
    {
      healthCmp.healthPoints = stats.health;
      combatCmp.damage = stats.damage;
    }
  }

}