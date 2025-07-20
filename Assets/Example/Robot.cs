using System;
using UnityEngine;

// RPG is the main namespace of our game.
namespace RPG.Example
{
  public class Robot : MonoBehaviour
  {
    private BetteryRegulations includedBattery;

    public Robot()
    {
      // Initialize the battery with a default health value.
      includedBattery = new Bettery(80f);
      includedBattery.CheckBatteryHealth();

      Charger.ChargeBettery(includedBattery);
      print("Robot battery charged to: " + includedBattery.health);
    }
  }


  public class Bettery : BetteryRegulations
  {
    public Bettery(float health) : base(health)
    {
      // Initialize the battery with a specific health value.
      this.health = health;
    }

    public void Drain(float amount)
    {
      health -= amount;
      if (health < 0)
      {
        health = 0;
      }
    }

    public void Recharge(float amount)
    {
      health += amount;
      if (health > 100)
      {
        health = 100;
      }
    }

    public override void CheckBatteryHealth()
    {
      if (health <= 0)
      {
        Debug.Log("Battery is dead.");
      }
      else if (health < 20)
      {
        Debug.Log("Battery is low.");
      }
      else
      {
        Debug.Log("Battery is healthy.");
      }
    }
  }


  static class Charger
  {
    public static bool IsCharging = false;

    public static void ChargeBettery(BetteryRegulations batteryToCharge)
    {
      IsCharging = true;
      batteryToCharge.health = 100; // Simulate charging the battery to full.
      Debug.Log("Charger started.");
    }
  }

  public abstract class BetteryRegulations
  {
    public float health;

    public BetteryRegulations(float health)
    {
      this.health = health;
    }

    public abstract void CheckBatteryHealth();
  }
}
