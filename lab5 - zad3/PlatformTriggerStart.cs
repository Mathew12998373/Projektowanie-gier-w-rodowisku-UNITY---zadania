using UnityEngine;

public class PlatformTriggerStart : MonoBehaviour
{
    public PlatformControllerWaypoints platformController;

    private void Awake()
    {
        if (platformController == null)
            platformController = GetComponentInParent<PlatformControllerWaypoints>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            platformController.StartMoving();
    }
}
