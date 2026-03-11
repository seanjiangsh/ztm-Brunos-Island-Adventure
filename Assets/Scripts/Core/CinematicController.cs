using UnityEngine;
using UnityEngine.Playables;
using RPG.Utility;

namespace RPG.Core
{
  public class CinematicController : MonoBehaviour
  {
    private PlayableDirector playableDirectorCmp;
    private Collider colliderCmp;

    private void Awake()
    {
      playableDirectorCmp = GetComponent<PlayableDirector>();
      colliderCmp = GetComponent<Collider>();
    }

    private void OnEnable()
    {
      playableDirectorCmp.played += HandlePlaying;
      playableDirectorCmp.stopped += HandleStopped;
    }

    private void OnDisable()
    {
      playableDirectorCmp.played -= HandlePlaying;
      playableDirectorCmp.stopped -= HandleStopped;
    }
    
    private void OnTriggerEnter(Collider other)
    {
      if (!other.CompareTag("Player")) return;

      playableDirectorCmp.Play();
      colliderCmp.enabled = false;
    }

    private void HandlePlaying(PlayableDirector director)
    {
      Debug.Log("Cinematic is playing");
    }

    private void HandleStopped(PlayableDirector director)
    {
      Debug.Log("Cinematic has stopped");
    }
  }
}