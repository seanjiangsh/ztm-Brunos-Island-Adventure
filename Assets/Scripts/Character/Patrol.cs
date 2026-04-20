using System;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.AI;

namespace RPG.Character
{
  public class Patrol : MonoBehaviour
  {
    [SerializeField] private GameObject splineGameObject;
    [SerializeField] private float walkDuration = 3f;
    [SerializeField] private float pauseDuration = 2f;

    private SplineContainer splineCmp;
    private NavMeshAgent agentCmp;

    private float splinePosition = 0f;
    private float splineLength = 0f;
    private float lengthWalked = 0f;
    private float walkTime = 0f;
    private float pauseTime = 0f;
    private bool isWalking = true;

    private void Awake()
    {
      splineCmp = splineGameObject != null
        ? splineGameObject.GetComponent<SplineContainer>()
        : GetComponent<SplineContainer>();

      if (splineCmp == null)
      {
        Debug.LogWarning($"{name}: missing SplineContainer reference for patrol.");
        return;
      }

      splineLength = Mathf.Max(splineCmp.CalculateLength(), 0.001f);
      agentCmp = GetComponent<NavMeshAgent>();

      if (agentCmp == null)
      {
        Debug.LogWarning($"{name}: missing NavMeshAgent component for patrol.");
      }
      // print($"{name} Spline Length: {splineLength}");
    }

    public Vector3 GetNextPosition()
    {
      if (splineCmp == null)
      {
        return transform.position;
      }

      // Get the position on the spline at the specified distance
      return splineCmp.EvaluatePosition(splinePosition);
    }

    public void CalculateNextPosition()
    {
      if (splineCmp == null || agentCmp == null)
      {
        return;
      }

      walkTime += Time.deltaTime;
      if (walkTime >= walkDuration)
      {
        isWalking = false;
      }

      if (!isWalking)
      {
        pauseTime += Time.deltaTime;
        if (pauseTime < pauseDuration)
        {
          return;
        }
        ResetTimers();
      }

      lengthWalked += Time.deltaTime * agentCmp.speed;
      if (lengthWalked >= splineLength)
      {
        lengthWalked = 0f; // Reset if we reach the end of the spline
      }

      splinePosition = Mathf.Clamp01(lengthWalked / splineLength);
    }

    public void ResetTimers()
    {
      isWalking = true;
      pauseTime = 0f;
      walkTime = 0f;
    }

    public Vector3 GetFartherOutPosition()
    {
      if (splineCmp == null)
      {
        return transform.position;
      }

      float tmpSplinePosition = splinePosition + 0.02f;
      if (tmpSplinePosition > 1f)
      {
        tmpSplinePosition = 0f; // Loop back to the start
      }
      return splineCmp.EvaluatePosition(tmpSplinePosition);
    }
  }
}