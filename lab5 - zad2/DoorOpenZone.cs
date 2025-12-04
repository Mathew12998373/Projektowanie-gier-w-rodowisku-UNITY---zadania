using UnityEngine;

public class DoorOpenZone : MonoBehaviour
{
    public SlidingDoor door;

    private void Awake()
    {
        if (door == null)
            door = GetComponentInParent<SlidingDoor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door?.SetOpen(true);
            Debug.Log("Player wszed³ w strefê drzwi - otwieram.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door?.SetOpen(false);
            Debug.Log("Player wyszed³ ze strefy drzwi - zamykam.");
        }
    }
}
