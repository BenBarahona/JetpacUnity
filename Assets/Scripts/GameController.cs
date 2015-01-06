using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject explosionObj;
    public GameObject enemySpawn;
    public GameObject meteor;
    public int level;
    public int currentEnemies;
    public float enemySpawnWait;
    public float startWait;

    int maxEnemies;


    // Use this for initialization
    void Start()
    {
        maxEnemies = 6;
        StartCoroutine(SpawnMeteors());
    }
	
    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnMeteors()
    {
        yield return new WaitForSeconds(startWait);
        while (Time.timeScale != 0)
        {
            if (currentEnemies < maxEnemies)
            {
                Vector3 position = enemySpawn.transform.position;
                position.y = Random.Range(-2f, 4.5f);

                Quaternion rotation = Quaternion.identity;
                if (Random.Range(0, 2) == 1)
                {
                    rotation = Quaternion.Euler(0, 180, 0);
                }

                Instantiate(meteor, position, rotation);

                currentEnemies++;
                Debug.Log("Spawn: " + currentEnemies);
            }

            yield return new WaitForSeconds(enemySpawnWait);
        }
    }

    public void killEnemy(GameObject enemy)
    {
        currentEnemies--;
        Instantiate(explosionObj, enemy.transform.position, Quaternion.identity);
        Destroy(enemy);
        Debug.Log("Kill: " + currentEnemies);
    }
}
