using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using UnityEngine.UIElements;

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
      Rotate();
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

    private void Rotate()
    {
      if (movementVector == Vector3.zero) return;
      Quaternion startRotation = transform.rotation;
      Quaternion endRotation = Quaternion.LookRotation(movementVector);
      transform.rotation = Quaternion.Lerp(startRotation, endRotation, Time.deltaTime * agent.angularSpeed);
    }

    public void MoveAgentByDestination(Vector3 destination)
    {
      agent.SetDestination(destination);
    }
  }
}

