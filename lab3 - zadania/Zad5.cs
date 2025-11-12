using UnityEngine;
using System.Collections.Generic;

public class CubeSpawner : MonoBehaviour
{
    public int liczbaKubow = 10;    
    private float rozmiar = 10f;    

    void Start()
    {
        HashSet<Vector3> zajete = new HashSet<Vector3>();

        for (int i = 0; i < liczbaKubow; i++)
        {
            Vector3 pozycja;
            do
            {
                float x = Random.Range(-rozmiar / 2f, rozmiar / 2f);
                float z = Random.Range(-rozmiar / 2f, rozmiar / 2f);
                pozycja = new Vector3(Mathf.Round(x), 0.5f, Mathf.Round(z));
            }
            while (zajete.Contains(pozycja));

            zajete.Add(pozycja);

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = pozycja;
        }
    }
}
