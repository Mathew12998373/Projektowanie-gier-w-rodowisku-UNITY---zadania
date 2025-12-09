using UnityEngine;

public class Zad3 : MonoBehaviour
{
    public float speed = 2f;
    private Vector3 pozycja_start;
    private Vector3 pozycja_cel;
    private bool ruch = true;

    private Vector3[] wierzcholki;
    private int indeks = 0;
    private const float bok = 10f;
    private const float eps = 0.001f;

    void Start()
    {
        pozycja_start = transform.position;
        wierzcholki = new Vector3[4];
        wierzcholki[0] = pozycja_start + Vector3.right * bok;
        wierzcholki[1] = wierzcholki[0] + Vector3.forward * bok;
        wierzcholki[2] = wierzcholki[1] + Vector3.left * bok;
        wierzcholki[3] = wierzcholki[2] + Vector3.back * bok;
        pozycja_cel = wierzcholki[indeks];
        UstawForwardNaCel();
    }

    void Update()
    {
        if (ruch)
        {
            transform.position = Vector3.MoveTowards(transform.position, pozycja_cel, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, pozycja_cel) <= eps)
            {
                transform.position = pozycja_cel;
                indeks = (indeks + 1) % wierzcholki.Length;
                pozycja_start = transform.position;
                pozycja_cel = wierzcholki[indeks];
                UstawForwardNaCel();
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pozycja_start, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, pozycja_start) <= eps)
            {
                ruch = true;
            }
        }
    }
    private void UstawForwardNaCel()
    {
        Vector3 kierunek = pozycja_cel - transform.position;
        if (kierunek.sqrMagnitude > 0.0001f)
        {
            transform.rotation = Quaternion.LookRotation(kierunek.normalized, Vector3.up);
        }
    }
}
