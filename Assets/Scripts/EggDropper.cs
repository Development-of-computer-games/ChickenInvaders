using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggDropper : MonoBehaviour
{
    [SerializeField] Mover prefabToSpawn;
    [SerializeField] Vector3 velocityOfSpawnedObject;
    [SerializeField] public float timeBetweenSpawns;

    void Start()
    {
        this.StartCoroutine(SpawnRoutine());
      
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenSpawns);
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, transform.position, Quaternion.identity);
            newObject.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObject);
           
        }
    }
}
