using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] prefabs; 
    public static float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy() {
        while (true) {
            int i = Random.Range(0, 4);

            if (i < 1) {
                Instantiate(prefabs[Random.Range(0, 3)], new Vector3(-3, 8, 0), Quaternion.identity);
            }
            else if (i >= 1 && i < 2) {
                Instantiate(prefabs[Random.Range(0, 3)], new Vector3(-1, 8, 0), Quaternion.identity);
            }
            else if (i >= 2 && i < 3) {
                Instantiate(prefabs[Random.Range(0, 3)], new Vector3(1, 8, 0), Quaternion.identity);
            }
            else if (i >= 3 && i < 4) {
                Instantiate(prefabs[Random.Range(0, 3)], new Vector3(3, 8, 0), Quaternion.identity);
            }
            

            yield return new WaitForSeconds(Random.Range(3, 5));
        }
    }
}
