using UnityEngine;
using System.Collections.Generic;

public class CubeSpawner : MonoBehaviour
{
    public int liczbaKubow = 10;     
    public float rozmiar = 10f;       
    public GameObject prefabCube;     

    void Start()
    {
        HashSet<Vector3> zajete = new HashSet<Vector3>();

        while (zajete.Count < liczbaKubow)
        {

            float x = Random.Range(-rozmiar / 2f, rozmiar / 2f);
            float z = Random.Range(-rozmiar / 2f, rozmiar / 2f);

            Vector3 pozycja = new Vector3(Mathf.Round(x), 0.5f, Mathf.Round(z));

            if (!zajete.Contains(pozycja))
            {
                zajete.Add(pozycja);

                GameObject cube;
                if (prefabCube != null)
                {
                    cube = Instantiate(prefabCube, pozycja, Quaternion.identity);
                }
                else
                {
                    cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = pozycja;
                }
            }
        }
    }
}
