using UnityEngine;
using UnityEngine.Playables;
using RPG.Utility;

namespace RPG.Core
{
  public class CinematicController : MonoBehaviour
  {
    private PlayableDirector playableDirectorCmp;
    private Collider colliderCmp;
    [SerializeField]private bool customPlayOnAwake = false;

    private void Awake()
    {
      playableDirectorCmp = GetComponent<PlayableDirector>();
      colliderCmp = GetComponent<Collider>();
    }

    private void Start()
    {
      colliderCmp.enabled = !PlayerPrefs.HasKey("SceneIndex");
      if (!customPlayOnAwake) return;
      
      colliderCmp.enabled = false;
      playableDirectorCmp.Play();
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
      EventManager.RaiseCutSceneUpdate(false);
    }

    private void HandleStopped(PlayableDirector director)
    {
      EventManager.RaiseCutSceneUpdate(true);
    }
  }
}