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
    [NonSerialized] public Vector3 originalForwardVector;
    [NonSerialized] public bool isMoving = false;

    private NavMeshAgent agent;
    private Animator animatorCmp;

    private Vector3 movementVector;

    private void Awake()
    {
      agent = GetComponent<NavMeshAgent>();
      animatorCmp = GetComponentInChildren<Animator>();
      originalForwardVector = transform.forward;
    }

    private void Start()
    {
      // Disable agent's rotation
      agent.updateRotation = false;
    }

    private void Update()
    {
      MovePlayer();
      MovementAnimator();
      if (CompareTag(Constants.PLAYER_TAG)) Rotate(movementVector);
    }

    public void HandleMove(InputAction.CallbackContext context)
    {

      Vector2 inputVector = context.ReadValue<Vector2>();
      if (context.performed)
      {
        isMoving = true;
        movementVector = new Vector3(inputVector.x, 0, inputVector.y);
      }
      else if (context.canceled)
      {
        isMoving = false;
        movementVector = Vector3.zero;
      }
    }
    // Debug.Log($"Input Vector: {inputVector}");


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
      isMoving = true;
    }


    public void MoveAgentByOffset(Vector3 offset)
    {
      agent.Move(offset);
      isMoving = true;
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

    private void MovementAnimator()
    {
      float speed = animatorCmp.GetFloat(Constants.ANIMATOR_SPEED_PARAM);
      float smoothening = Time.deltaTime * agent.acceleration;

      if (isMoving)
      {
        speed += smoothening;
      }
      else
      {
        speed -= smoothening;
      }

      speed = Mathf.Clamp(speed, 0, 1);
      animatorCmp.SetFloat(Constants.ANIMATOR_SPEED_PARAM, speed);
    }
  }
}
