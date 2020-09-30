using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlockSpawn : MonoBehaviour
{
    public GameObject[] prefabs; 

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
            //Instantiate(prefabs[0], new Vector2(0, 12), Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(1, 3));
        }
    }
}
