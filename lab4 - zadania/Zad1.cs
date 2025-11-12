using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Zad1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    // obiekt do generowania
    public GameObject block;
    public int iloscKubow = 10;
    public Material[] materials;
    void Start()
    {
        // w momecie uruchomienia generuje 10 kostek w losowych miejscach
        List<int> pozycje_x = new List<int>(Enumerable.Range(0, 20).OrderBy(x => Guid.NewGuid()).Take(10));
        List<int> pozycje_z = new List<int>(Enumerable.Range(0, 20).OrderBy(x => Guid.NewGuid()).Take(10));

        for (int i = 0; i < 10; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 5, pozycje_z[i]));
        }
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }
        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
        {
            Bounds bounds = rend.bounds;
            for (int i = 0; i < iloscKubow; i++)
            {
                float x = UnityEngine.Random.Range(bounds.min.x, bounds.max.x);
                float z = UnityEngine.Random.Range(bounds.min.z, bounds.max.z);
                float y = bounds.max.y + 0.5f;

                positions.Add(new Vector3(x, y, z));
            }
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywo³ano coroutine");
        foreach (Vector3 pos in positions)
        {
            GameObject obj = Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);

            // NOWE: losowy materia³
            if (materials != null && materials.Length > 0)
            {
                Material losowyMat = materials[UnityEngine.Random.Range(0, materials.Length)];
                obj.GetComponent<Renderer>().material = losowyMat;
            }

            yield return new WaitForSeconds(this.delay);
        }

        StopCoroutine(GenerujObiekt());
    }
}
