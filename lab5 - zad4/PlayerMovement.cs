using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float predkosc = 5f;
    private CharacterController kontroler;
    private Vector3 predkosc_2;
    private float grawitacja = -9.81f;
    public float wysokosc_skoku = 1.5f;

    void Start()
    {
        kontroler = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(h, 0, v);
        kontroler.Move(move * predkosc * Time.deltaTime);

        if (kontroler.isGrounded && predkosc_2.y < 0)
            predkosc_2.y = -2f;

        if (Input.GetButtonDown("Jump") && kontroler.isGrounded)
            predkosc_2.y = Mathf.Sqrt(wysokosc_skoku * -2f * grawitacja);

        predkosc_2.y += grawitacja * Time.deltaTime;
        kontroler.Move(predkosc_2 * Time.deltaTime);
    }

    public void LaunchUp(float multiplier)
    {
        predkosc_2.y = Mathf.Sqrt(wysokosc_skoku * -2f * grawitacja) * multiplier;
    }
}
