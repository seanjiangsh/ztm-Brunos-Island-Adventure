using NUnit.Framework;
using UnityEngine;

namespace RPG.Quests
{
  [CreateAssetMenu(
     fileName = "New Quest Item",
     menuName = "RPG/Quests/Quest Item",
     order = 1
  )]
  public class QuestItemSO : ScriptableObject
  {
    public string itemName;
    public Sprite itemIcon;
    [TextArea]
    public string itemDescription;
  }
}