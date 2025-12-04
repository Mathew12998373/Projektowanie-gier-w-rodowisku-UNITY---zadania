using UnityEngine;

public class PlatformTriggerStart : MonoBehaviour
{
    public PlatformControllerHorizontal platformController;

    private void Awake()
    {
        if (platformController == null)
            platformController = GetComponentInParent<PlatformControllerHorizontal>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            platformController.StartMoving();
        }
    }
}
