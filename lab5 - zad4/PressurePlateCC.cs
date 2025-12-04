using UnityEngine;

public class PressurePlateCC : MonoBehaviour
{
    public float sila_wyrzutu = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.LaunchUp(sila_wyrzutu);
                Debug.Log("Gracz wyrzucony w górê przez p³ytê!");
            }
        }
    }
}
