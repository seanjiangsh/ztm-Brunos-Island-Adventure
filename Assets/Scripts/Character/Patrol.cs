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
      splineCmp = splineGameObject.GetComponent<SplineContainer>();
    }

    public Vector3 GetNextPosition()
    {
      // Get the position on the spline at the specified distance
      return splineCmp.EvaluatePosition(0);
    }
  }
}