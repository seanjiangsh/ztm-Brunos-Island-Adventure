using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using UnityEngine.UIElements;
using RPG.Utility;

namespace RPG.Character
{
  [RequireComponent(typeof(NavMeshAgent))]
  public class Movement : MonoBehaviour
  {
    private NavMeshAgent agent;

    private Vector3 movementVector;

    private void Awake()
    {
      agent = GetComponent<NavMeshAgent>();
      if (agent == null)
      {
        Debug.LogError("NavMeshAgent component is missing on this GameObject.");
      }
    }

    private void Update()
    {
      MovePlayer();
      if (CompareTag(Constants.PLAYER_TAG)) Rotate(movementVector);
    }

    public void HandleMove(InputAction.CallbackContext context)
    {

      Vector2 inputVector = context.ReadValue<Vector2>();
      // Debug.Log($"Input Vector: {inputVector}");

      if (context.performed)
      {
        movementVector = new Vector3(inputVector.x, 0, inputVector.y);
      }
      else if (context.canceled)
      {
        movementVector = Vector3.zero;
      }
    }

    private void MovePlayer()
    {
      if (movementVector != Vector3.zero)
      {
        Vector3 offset = movementVector * Time.deltaTime * agent.speed;
        agent.Move(offset);
      }
    }

    public void Rotate(Vector3 newForwardVector)
    {
      if (newForwardVector == Vector3.zero) return;
      Quaternion startRotation = transform.rotation;
      Quaternion endRotation = Quaternion.LookRotation(newForwardVector);
      transform.rotation = Quaternion.Lerp(startRotation, endRotation, Time.deltaTime * agent.angularSpeed);
    }

    public void MoveAgentByDestination(Vector3 destination)
    {
      agent.SetDestination(destination);
    }


    public void MoveAgentByOffset(Vector3 offset)
    {
      agent.Move(offset);
    }

    public void StopMovingAgent()
    {
      agent.isStopped = true;
      agent.ResetPath();
    }

    public bool ReachedDestination()
    {
      if (agent.pathPending) return false;
      if (agent.remainingDistance > agent.stoppingDistance) return false;
      if (agent.hasPath || agent.velocity.sqrMagnitude != 0f) return false;

      return true;
    }

    public void UpdateAgentSpeed(float newSpeed)
    {
      agent.speed = newSpeed;
    }
  }
}
