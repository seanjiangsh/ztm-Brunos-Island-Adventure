
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Utility
{
  public static class PlayerPrefsUtility
  {
    public static void SetString(string key, List<string> value)
    {
      string serializedValue = string.Join(",", value);
      PlayerPrefs.SetString(key, serializedValue);

      Debug.Log($"Saved List<string> to PlayerPrefs with key '{key}': {serializedValue}");
    }
  }
}