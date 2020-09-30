using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{
    public GameObject[] prefabs;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prefabs[3], new Vector3(3, -4, 0), Quaternion.identity);
        
        for (int i = 0; i < 3; i++) {
            Instantiate(prefabs[Random.Range(0, 3)], new Vector3((-3 + 2*i), -4, 0), Quaternion.identity);
        }

        for (int i = 0; i < 4; i++) {
            Instantiate(prefabs[Random.Range(0, 3)], new Vector3((-3 + 2*i), -2, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
