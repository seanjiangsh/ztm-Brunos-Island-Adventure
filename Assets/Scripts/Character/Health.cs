using UnityEngine;
using System;

namespace RPG.Character
{
  public class Health : MonoBehaviour
  {
    [NonSerialized] public float healthPoints = 0f;

    public void TakeDamage(float damage)
    {
      healthPoints = Mathf.Max(healthPoints - damage, 0);
      Debug.Log($"{gameObject.name} took {damage} damage. Remaining HP: {healthPoints}");
      if (healthPoints <= 0)
      {
        Debug.Log($"{gameObject.name} has died.");
      }
    }
  }
}