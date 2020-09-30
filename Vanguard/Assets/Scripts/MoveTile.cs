using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTile : MonoBehaviour
{
    private GameObject[] list;
    private GameObject[] allowed;
    private int i;
    public float temp1, temp2;
    private bool canMove, complete;
    private Vector2 pos1, pos2;
    private float moveHorizontal, moveVertical;

    // Start is called before the first frame update
    void Start()
    {
        list = GameObject.FindGameObjectsWithTag("Hero");
        canMove = true;
        complete = false;
    }

    // Update is called once per frame
    void Update()
    {   
        
        if (canMove) {
            if (Input.GetKeyDown("left")) {
                moveHorizontal = -1;
            }
            if (Input.GetKeyDown("right")) {
                moveHorizontal = 1;
            }
            if (Input.GetKeyDown("up")) {
                moveVertical = 1;
            }
            if (Input.GetKeyDown("down")) {
                moveVertical = -1;
            }
        }
        else {
            moveHorizontal = 0f;
            moveVertical = 0f;
        }

        if ((moveHorizontal == 1) && canMove) {
            for (i=0; i<(list.Length); i++) {
                if (list[i].transform.position.x - transform.position.x == 2 && (transform.position.y == list[i].transform.position.y)) {
                    canMove = false;
                    complete = false;
                    temp1 = list[i].transform.position.x;
                    temp2 = transform.position.x;
                    pos1 = list[i].transform.position;
                    pos2 = transform.position;
                    StartCoroutine(swap(i, "right"));
                    //list[i].transform.Translate(new Vector3(-2, 0, 0));
                    //transform.Translate(new Vector3(2, 0, 0));
                    break;
                }
            }
        }

        if ((moveHorizontal == -1) && canMove) {
            for (i=0; i<(list.Length); i++) {
                if (list[i].transform.position.x - transform.position.x == (-2) && (transform.position.y == list[i].transform.position.y)) {
                    canMove = false;
                    complete = false;
                    temp1 = list[i].transform.position.x;
                    temp2 = transform.position.x;
                    pos1 = list[i].transform.position;
                    pos2 = transform.position;
                    StartCoroutine(swap(i, "left"));
                    //list[i].transform.Translate(new Vector3(2, 0, 0));
                    //transform.Translate(new Vector3(-2, 0, 0));
                    break;
                }
            }
        }

        if ((moveVertical == 1) && canMove) {
            for (i=0; i<(list.Length); i++) {
                if ((list[i].transform.position.y - transform.position.y == 2) && (transform.position.x == list[i].transform.position.x)) {
                    canMove = false;
                    complete = false;
                    temp1 = list[i].transform.position.y;
                    temp2 = transform.position.y;
                    pos1 = list[i].transform.position;
                    pos2 = transform.position;
                    StartCoroutine(swap(i, "up"));
                    //list[i].transform.Translate(new Vector3(0, -2, 0));
                    //transform.Translate(new Vector3(0, 2, 0));
                    break;
                }
            }
        }

        if ((moveVertical == -1) && canMove) {
            for (i=0; i<(list.Length); i++) {
                if (list[i].transform.position.y - transform.position.y == (-2) && (transform.position.x == list[i].transform.position.x)) {
                    canMove = false;
                    complete = false;
                    temp1 = list[i].transform.position.y;
                    temp2 = transform.position.y;
                    pos1 = list[i].transform.position;
                    pos2 = transform.position;
                    StartCoroutine(swap(i, "down"));
                    //list[i].transform.Translate(new Vector3(0, 2, 0));
                    //transform.Translate(new Vector3(0, -2, 0));
                    break;
                }
            }
        }
    }

    IEnumerator swap(int i, string orientation) {
        while (!complete) {
            if (orientation == "right") {
                list[i].transform.Translate(new Vector3(-10.0f * Time.deltaTime, 0, 0));
                transform.Translate(new Vector3(10.0f * Time.deltaTime, 0, 0));
                
                if (transform.position.x >= temp1) {
                    transform.position = pos1;
                    list[i].transform.position = pos2;
                    complete = true;
                    canMove = true;
                    //yield return new WaitForSeconds(2.0f);
                }
            }
            else if (orientation == "left") {
                list[i].transform.Translate(new Vector3(10.0f * Time.deltaTime, 0, 0));
                transform.Translate(new Vector3(-10.0f * Time.deltaTime, 0, 0));

                if (transform.position.x <= temp1) {
                    transform.position = pos1;
                    list[i].transform.position = pos2;
                    complete = true;
                    canMove = true;
                    //yield return new WaitForSeconds(2.0f);
                }
            }
            else if (orientation == "up") {
                list[i].transform.Translate(new Vector3(0, -10.0f * Time.deltaTime, 0));
                transform.Translate(new Vector3(0, 10.0f * Time.deltaTime, 0));

                if (transform.position.y >= temp1) {
                    transform.position = pos1;
                    list[i].transform.position = pos2;
                    complete = true;
                    canMove = true;
                    //yield return new WaitForSeconds(2.0f);
                }
            }
            else if (orientation == "down") {
                list[i].transform.Translate(new Vector3(0, 10.0f * Time.deltaTime, 0));
                transform.Translate(new Vector3(0, -10.0f * Time.deltaTime, 0));

                if (transform.position.y <= temp1) {
                    transform.position = pos1;
                    list[i].transform.position = pos2;
                    complete = true;
                    canMove = true;
                    //yield return new WaitForSeconds(2.0f);
                }
            }

            yield return new WaitForSeconds(0f);
        }
    }

}
