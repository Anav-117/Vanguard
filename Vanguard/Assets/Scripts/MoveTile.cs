using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTile : MonoBehaviour
{
    private GameObject[] list;
    private GameObject[] allowed;
    private int i;
    private bool canMove;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        list = GameObject.FindGameObjectsWithTag("Hero");
        canMove = true;
        timer = 0.65f;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        timer -= Time.deltaTime;
        if (timer <= 0) {
            timer = 0.65f;
            canMove = true;
        }


        if ((moveHorizontal > 0) && canMove) {
            canMove = false;
            for (i=0; i<(list.Length); i++) {
                if (list[i].transform.position.x - transform.position.x == 2 && (transform.position.y == list[i].transform.position.y)) {
                    list[i].transform.Translate(new Vector3(-2, 0, 0));
                    transform.Translate(new Vector3(2, 0, 0));
                    break;
                }
            }
        }

        if ((moveHorizontal < 0) && canMove) {
            canMove = false;
            for (i=0; i<(list.Length); i++) {
                if (list[i].transform.position.x - transform.position.x == (-2) && (transform.position.y == list[i].transform.position.y)) {
                    list[i].transform.Translate(new Vector3(2, 0, 0));
                    transform.Translate(new Vector3(-2, 0, 0));
                    break;
                }
            }
        }

        if ((moveVertical > 0) && canMove) {
            canMove = false;
            for (i=0; i<(list.Length); i++) {
                if ((list[i].transform.position.y - transform.position.y == 2) && (transform.position.x == list[i].transform.position.x)) {
                    list[i].transform.Translate(new Vector3(0, -2, 0));
                    transform.Translate(new Vector3(0, 2, 0));
                    break;
                }
            }
        }

        if ((moveVertical < 0) && canMove) {
            canMove = false;
            for (i=0; i<(list.Length); i++) {
                if (list[i].transform.position.y - transform.position.y == (-2) && (transform.position.x == list[i].transform.position.x)) {
                    list[i].transform.Translate(new Vector3(0, 2, 0));
                    transform.Translate(new Vector3(0, -2, 0));
                    break;
                }
            }
        }
    }

}
