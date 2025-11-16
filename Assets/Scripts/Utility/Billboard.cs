using UnityEngine;

namespace RPG.Utility
{
  public class Billboard : MonoBehaviour
  {
    private GameObject mainCamera;

    private void Awake()
    {
      mainCamera = GameObject.FindGameObjectWithTag(Constants.MAIN_CAMERA_TAG);
    }

    // LateUpdate is called after all Update functions have been called
    // This is to ensure the billboard updates after the camera has moved
    // And to prevent race conditions with other scripts
    private void LateUpdate()
    {
      if (mainCamera == null) return;

      Vector3 cameraDirection = transform.position + mainCamera.transform.forward;
      transform.LookAt(cameraDirection);
    }
  }
}