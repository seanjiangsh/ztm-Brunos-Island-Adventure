using UnityEngine;

namespace RPG.Character
{
  public class AttackSoundEffect : MonoBehaviour
  {
    AudioSource audioSourceCmp;

    private void Awake()
    {
      audioSourceCmp = GetComponent<AudioSource>();
    }

    public void OnStartAttack()
    {
      if (audioSourceCmp.clip == null) return;
      
      audioSourceCmp.Play();
    }
  }
}