using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using RPG.Utility;

namespace RPG.Core
{
  public static class SceneTranstion
  {
    public static IEnumerator Initiate(int sceneIndex)
    {
      AudioSource audioSource = GameObject.FindGameObjectWithTag(
          Constants.GAME_MANAGER_TAG
      ).GetComponent<AudioSource>();

      float duration = 2f;
      while (audioSource.volume > 0)
      {
        audioSource.volume -= Time.deltaTime / duration;
        yield return new WaitForEndOfFrame();
      }

      SceneManager.LoadScene(sceneIndex);
    }
  }
}