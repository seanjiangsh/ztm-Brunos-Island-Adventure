using System;
using UnityEngine;
using UnityEngine.Splines;

namespace RPG.Character
{
  public class Patrol : MonoBehaviour
  {
    [SerializeField] private GameObject splineGameObject;
    private SplineContainer splineCmp;
    private float splinePosition = 0f;

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
      return splineCmp.EvaluatePosition(splinePosition);
    }

    public void CalculateNextPosition()
    {
      splinePosition += Time.deltaTime;

      if (splinePosition > 1f)
      {
        splinePosition = 0f; // Loop back to the start
      }

      print($"Current Spline Position: {splinePosition}");
    }
  }
}