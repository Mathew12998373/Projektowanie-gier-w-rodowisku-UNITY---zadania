using UnityEngine;

public class Zad3_1 : MonoBehaviour
{
    public float speed = 2f;
    private Vector3 pozycja_start;
    private Vector3 pozycja_cel;
    private bool ruch = true;

    void Start()
    {
        pozycja_start = transform.position;
        pozycja_cel = pozycja_start + Vector3.right * 10f;
    }

    void Update()
    {
        if (ruch)
        {
            transform.position = Vector3.MoveTowards(transform.position, pozycja_cel, speed * Time.deltaTime);
            if (transform.position == pozycja_cel)
            {
                ruch = false;
            }

        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pozycja_start, speed * Time.deltaTime);
            if (transform.position == pozycja_start)
            {
                ruch = true;
            }

        }
    }
}