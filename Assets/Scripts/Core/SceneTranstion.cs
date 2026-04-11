using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RPG.Core
{
  public static class SceneTranstion
  {
    public static IEnumerator Initiate(int sceneIndex)
    {
      yield return true;
      SceneManager.LoadScene(sceneIndex);
    }
  }
}