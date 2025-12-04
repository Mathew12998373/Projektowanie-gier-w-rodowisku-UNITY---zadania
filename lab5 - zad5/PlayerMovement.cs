using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float predkosc = 5f;
    public float wysokosc_skoku = 1.5f;
    public float grawitacja = -9.81f;

    private CharacterController kontroler;
    private Vector3 prekosc_2;

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


        if (kontroler.isGrounded && prekosc_2.y < 0)
            prekosc_2.y = -2f;


        if (Input.GetButtonDown("Jump") && kontroler.isGrounded)
            prekosc_2.y = Mathf.Sqrt(wysokosc_skoku * -2f * grawitacja);

        prekosc_2.y += grawitacja * Time.deltaTime;
        kontroler.Move(prekosc_2 * Time.deltaTime);

    }
}
