using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubesAndSpheres : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject spherePrefab;
    public int numCubes = 5;
    public int numSpheres = 5;
    private float spawnInterval = 5.0f;

    public Vector3 planePosition;
    public Vector3 planeScale;





    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        Vector3 playerPos = transform.position;
        Vector3 forward = transform.forward;

        // Determine the total number of objects to spawn
        int totalObjects = Mathf.Max(numCubes, numSpheres);

        for (int i = 0; i < totalObjects; i++)
        {
            // Spawn a cube if there are still cubes left to spawn
            if (i < numCubes)
            {
                Vector3 randomPos = playerPos + forward * Random.Range(10f, 20f) + Random.onUnitSphere * 5f;
                Instantiate(cubePrefab, randomPos, Quaternion.identity);
                yield return new WaitForSeconds(spawnInterval);
            }

            // Spawn a sphere if there are still spheres left to spawn
            if (i < numSpheres)
            {
                Vector3 randomPos = playerPos + forward * Random.Range(10f, 20f) + Random.onUnitSphere * 5f;
                Instantiate(spherePrefab, randomPos, Quaternion.identity);
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
