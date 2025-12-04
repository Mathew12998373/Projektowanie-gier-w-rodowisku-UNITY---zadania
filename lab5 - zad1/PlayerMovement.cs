using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float predkosc = 5f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 ruch = new Vector3(h, 0, v) * predkosc * Time.deltaTime;
        transform.Translate(ruch, Space.World);
    }
}
