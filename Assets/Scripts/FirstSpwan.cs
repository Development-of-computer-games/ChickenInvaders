using System.Collections;
using UnityEngine;

/**
 * This component instantiates a given prefab at random time intervals and random bias from its object position.
 */
public class FirstSpwan : MonoBehaviour
{
    [SerializeField] GameObject prefabToSpawn;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float minTimeBetweenSpawns = 1f;
    [Tooltip("Spaces between chickens")] [SerializeField] float offSet = 0.5f;
    [Tooltip("Chickens rows")] [SerializeField] int rows;
    [Tooltip("Space between rows")] [SerializeField] int rowSpace;
    [Tooltip("Number of chickens")] [SerializeField] int numOfChickens;
    GameObject[] chickens = null;
    

    void Start()
    {
       StartCoroutine(spwan());
    }

    private IEnumerator spwan()
    {
        
        
        Vector3 position = transform.position;
        float startXpos = position.x;
      
            for (int i = 0; i < numOfChickens; i++)
            {
                // new line
                if (i % (numOfChickens / rows) == 0)
                {
                    position.y -= rowSpace;
                    position.x = startXpos;
                }
                GameObject newObject = Instantiate(prefabToSpawn.gameObject, position, Quaternion.identity);
          
         
           // 
            position.x += offSet;
                yield return new WaitForSeconds(minTimeBetweenSpawns);

            }

  

    }

    
    private void Update()
    {
        chickens = GameObject.FindGameObjectsWithTag("Chicken");
        /*  if (chickens == null || chickens.Length != numOfChickens - 1)
          {

          }
          if (chickens.Length == numOfChickens - 1)*/
        //  {
        if (chickens != null)
        {
            int randomNum = Random.Range(0, chickens.Length - 1);
            chickens[randomNum].GetComponent<EggDropper>().enabled = true;
            chickens[randomNum].GetComponent<EggDropper>().timeBetweenSpawns = Random.Range(2, 30);
          
                if (chickens[randomNum].GetComponent<MovingChicken>().isMoving == false)
                {
                    Vector3 startPos = chickens[randomNum].transform.position;
                    Vector3 endPos = chickens[randomNum].transform.position;
                    endPos.x -= 3;
                    Debug.Log(startPos);
                    Debug.Log(endPos);

                    chickens[randomNum].GetComponent<MovingChicken>().start = startPos;
                    chickens[randomNum].GetComponent<MovingChicken>().end = endPos;
                    chickens[randomNum].GetComponent<MovingChicken>().isMoving = true;
                }
            

        }

      
      //  }
    }

}
