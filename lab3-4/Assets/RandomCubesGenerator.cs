using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomCubesGenerator : MonoBehaviour
{
    public int numberOfObjectsToGenerate = 10; // Ilość obiektów do wygenerowania
    public GameObject[] objectPrefabs; // Tablica prefabrykatów obiektów
    public Material[] materials; // Tablica materiałów

    private List<Vector3> positions = new List<Vector3>();
    public float delay = 1.0f;

    void Start()
    {
        // Pozycje x i z pobierane z pozycji platformy, do której skrypt jest dołączony
        Transform platformTransform = transform; // Zakładamy, że skrypt jest dołączony do platformy

        for (int i = 0; i < numberOfObjectsToGenerate; i++)
        {
            float randomX = platformTransform.position.x + Random.Range(-10f, 10f);
            float randomZ = platformTransform.position.z + Random.Range(-10f, 10f);
            this.positions.Add(new Vector3(randomX, 5, randomZ));
        }

        // Uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {
        
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("Wywołano coroutine");
        for (int i = 0; i < numberOfObjectsToGenerate; i++)
        {
            GameObject newObject = Instantiate(objectPrefabs[Random.Range(0, objectPrefabs.Length)], positions[i], Quaternion.identity);

            // Losowe przypisanie materiału
            if (materials.Length > 0)
            {
                Material randomMaterial = materials[Random.Range(0, materials.Length)];
                Renderer objectRenderer = newObject.GetComponent<Renderer>();
                if (objectRenderer != null)
                {
                    objectRenderer.material = randomMaterial;
                }
            }

            yield return new WaitForSeconds(delay);
        }
    }
}