using UnityEngine;

public class PlayerCollisionCheck : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Uruchomiono");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Gracz wszed³ w kontakt z przeszkod¹: " + collision.gameObject.name);
        }
    }
}
