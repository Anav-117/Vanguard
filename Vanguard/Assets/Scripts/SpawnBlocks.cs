using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{
    public AudioSource BGSound;
    private bool FadeSound;
    public GameObject[] prefabs;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prefabs[3], new Vector3(3, -4, 0), Quaternion.identity);
        Instantiate(prefabs[0], new Vector3(-3, -4, 0), Quaternion.identity);
        Instantiate(prefabs[1], new Vector3(-1, -4, 0), Quaternion.identity);
        Instantiate(prefabs[2], new Vector3(1, -4, 0), Quaternion.identity);

        for (int i = 0; i < 4; i++) {
            Instantiate(prefabs[Random.Range(0, 3)], new Vector3((-3 + 2*i), -2, 0), Quaternion.identity);
        }

        FadeSound = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (FadeSound) {
            BGSound.volume += 0.05f * Time.deltaTime;
            if (BGSound.volume >= 1) {
                FadeSound = false;
            }
        }
    }

}
