using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerOBjects : MonoBehaviour
{
    public GameObject[] prefab;
    public int poolSize = 10;
    public Transform spawnPoint;
    public float initialSpeed ;
    public float speedIncreaseRate ;

    private List<GameObject> pooledObjects = new List<GameObject>();
    private float currentSpeed;
    private int random;

    void Start()
    {
        // Crear un pool de objetos
        for (int i = 0; i < poolSize; i++)
        {
            random = Random.Range(0, prefab.Length);
            GameObject obj = Instantiate(prefab[random]);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }

        currentSpeed = initialSpeed;
        InvokeRepeating("SpawnObjectFromPool", 1f, 2f);
    }

    private void SpawnObjectFromPool()
    {
        GameObject newObj = GetPooledObject();
        if (newObj != null)
        {
            float randomX = Random.Range(-5f, 5f);
            Vector3 spawnPosition = new Vector3(randomX, spawnPoint.position.y, spawnPoint.position.z);

            newObj.transform.position = spawnPosition;
            newObj.SetActive(true);

            // Aplica velocidad al objeto
            Rigidbody rb = newObj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = currentSpeed * -spawnPoint.forward;
                currentSpeed += speedIncreaseRate;
            }
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        random = Random.Range(0, prefab.Length);
        GameObject newObj = Instantiate(prefab[random]);
        newObj.SetActive(false);
        pooledObjects.Add(newObj);
        return newObj;
    }

    void Update()
    {
        // Verifica la posición en el eje Z de los objetos y desactívalos si están en -20
        foreach (var obj in pooledObjects)
        {
            if (obj.activeInHierarchy && obj.transform.position.z <= -20)
            {
                obj.SetActive(false);
            }
        }
    }
}
