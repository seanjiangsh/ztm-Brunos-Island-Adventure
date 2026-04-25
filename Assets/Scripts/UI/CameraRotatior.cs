
using UnityEngine;

namespace RPG.UI
{
  public class CameraRotating : MonoBehaviour
  {
    [SerializeField] private float rotationSpeed = 20f;

    private void Update()
    {
      // Rotate the camera around the Y-axis at a constant speed
      transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
  }
}