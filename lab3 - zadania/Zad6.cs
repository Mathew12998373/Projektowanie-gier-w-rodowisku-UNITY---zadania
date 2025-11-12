using UnityEngine;

public class Zad6 : MonoBehaviour
{
    public Transform target;
    public float czas = 0.3f;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position,target.position,ref velocity,czas);

        transform.position = Vector3.Lerp(transform.position, target.position, 0.05f);

        transform.position = Vector3.Slerp(transform.position, target.position, 0.05f);
    }
}
