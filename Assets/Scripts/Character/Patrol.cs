using UnityEngine;
using UnityEngine.Splines;

namespace RPG.Character
{
  public class Patrol : MonoBehaviour
  {
    [SerializeField] private GameObject splineGameObject;
    private SplineContainer splineCmp;

    private void Awake()
    {
      if (splineGameObject == null)
      {
        Debug.LogWarning($"{name}: does not have a spline.");
        return;
      }
      splineCmp = splineGameObject.GetComponent<SplineContainer>();
    }

    public Vector3 GetNextPosition()
    {
      // Get the position on the spline at the specified distance
      return splineCmp.EvaluatePosition(0);
    }
  }
}