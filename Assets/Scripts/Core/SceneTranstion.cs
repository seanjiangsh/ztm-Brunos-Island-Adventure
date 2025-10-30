using UnityEngine;
using UnityEngine.SceneManagement;

namespace RPG.Core
{
  public static class SceneTranstion
  {
    public static void Initiate(int sceneIndex)
    {
      SceneManager.LoadScene(sceneIndex);
    }
  }
}