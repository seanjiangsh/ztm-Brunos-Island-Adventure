using System;
using UnityEngine;
using RPG.Core;
using RPG.Quests; 
using RPG.Utility;

namespace RPG.Character
{
  public class PlayerController : MonoBehaviour
  {
    [NonSerialized] public Health healthCmp;
    [NonSerialized] public Combat combatCmp;

    public CharacterStatsSO stats;
    private GameObject axeWeapon;
    private GameObject swordWeapon;
    public Weapons currentWeapon = Weapons.Axe;

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
      axeWeapon = GameObject.FindWithTag(Constants.AXE_TAG);
      swordWeapon = GameObject.FindWithTag(Constants.SWORD_TAG);
    }

    private void Start()
    {
      if(PlayerPrefs.HasKey("Health"))
      {
        healthCmp.healthPoints = PlayerPrefs.GetFloat("Health");
        healthCmp.potionCount = PlayerPrefs.GetInt("Potions");
        combatCmp.damage = PlayerPrefs.GetFloat("Damage");
        currentWeapon = (Weapons)PlayerPrefs.GetInt("Weapon");
      }
      else
      {
        healthCmp.healthPoints = stats.health;
        combatCmp.damage = stats.damage;
      }
      
      EventManager.RaiseChangePlayerHealth(healthCmp.healthPoints);
      EventManager.RaiseChangePlayerPotion(healthCmp.potionCount);
      SetWeapon();
    }

    private void OnEnable()
    {
      EventManager.OnApplyReward += HandleReward;
    }

    private void OnDisable()
    {
      EventManager.OnApplyReward -= HandleReward;
    }

    private void HandleReward(RewardSO reward)
    {
      healthCmp.healthPoints += reward.bonusHealth;
      healthCmp.potionCount += reward.bonusPotions;
      combatCmp.damage += reward.bonusDamage;

      EventManager.RaiseChangePlayerHealth(healthCmp.healthPoints);
      EventManager.RaiseChangePlayerPotion(healthCmp.potionCount);

      if (reward.forceWeaponSwap)
      {
        currentWeapon = reward.weapons;
        SetWeapon();
      }
    }

    private void SetWeapon()
    {
      if (currentWeapon == Weapons.Axe)
      {
        axeWeapon.SetActive(true);
        swordWeapon.SetActive(false);
      }
      else if (currentWeapon == Weapons.Sword)
      {
        axeWeapon.SetActive(false);
        swordWeapon.SetActive(true);
      }
    }
  }
}