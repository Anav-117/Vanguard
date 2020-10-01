using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoveTile : MonoBehaviour
{
    private GameObject[] list;
    private GameObject[] allowed;
    private int i;
    private float temp1, temp2;
    private bool canMove, complete;
    private Vector2 pos1, pos2;
    private float moveHorizontal, moveVertical;
    public static bool Paused;
    private AudioSource Sound;
    public static int Score;

    private GameObject[,] board;
    // Start is called before the first frame update
    void Start()
    {
        list = GameObject.FindGameObjectsWithTag("Green");
        list = list.Concat(GameObject.FindGameObjectsWithTag("Blue")).ToArray();
        list = list.Concat(GameObject.FindGameObjectsWithTag("Red")).ToArray();
        //list = GameObject.FindGameObjectsWithTag("Blue");
        //list = GameObject.FindGameObjectsWithTag("Red");
        canMove = true;
        complete = false;
        Paused = false;
        Sound = GetComponent<AudioSource>();
        Score = 0;

        board = new GameObject [2,4];

        fillBoard();
        
        //Debug.Log(board);
    }

    // Update is called once per frame
    void Update()
    {   
        if (!Paused) {
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
                        Sound.Play();
                        StartCoroutine(swap(i, "right"));
                        boardUpdate("right");
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
                        Sound.Play();
                        StartCoroutine(swap(i, "left"));
                        boardUpdate("left");
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
                        Sound.Play();
                        StartCoroutine(swap(i, "up"));
                        boardUpdate("up");
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
                        Sound.Play();
                        StartCoroutine(swap(i, "down"));
                        boardUpdate("down");
                        //list[i].transform.Translate(new Vector3(0, 2, 0));
                        //transform.Translate(new Vector3(0, -2, 0));
                        break;
                    }
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
                    flushBoard();
                    //Sound.Play();
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
                    flushBoard();
                    //Sound.Play();
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
                    flushBoard();
                    //Sound.Play();
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
                    flushBoard();
                    //Sound.Play();
                    //yield return new WaitForSeconds(2.0f);
                }
            }

            yield return new WaitForSeconds(0f);
        }
    }


    void fillBoard() {
        for (int i = 0; i < 2; i++) {
            for (int j = 0; j < 4; j++) {
                for (int k = 0; k < list.Length; k++) {
                    //Debug.Log((list[k].transform.position.y)/(-2));
                    if (((list[k].transform.position.x + 3)/2) == j && ((list[k].transform.position.y)/(-2)) - 1 == i) {
                        board[i,j] = list[k];
                        break;
                    }
                }
            }
        }
        board[1, 3] = GameObject.FindWithTag("Player");
    }

    void boardUpdate(string orientation) {
        if (orientation == "right") {
            for (int i = 0; i < 2; i++) {
                for (int j = 0; j < 4; j++) {
                    if (board[i,j].tag == "Player" && j < 3) {
                        GameObject temp = board[i,j];
                        board[i,j] = board[i,j+1];
                        board[i,j+1] = temp;
                        break;
                    }
                }
            }
        }

        if (orientation == "left") {
            for (int i = 0; i < 2; i++) {
                for (int j = 0; j < 4; j++) {
                    if (board[i,j].tag == "Player" && j > 0) {
                        GameObject temp = board[i,j];
                        board[i,j] = board[i,j-1];
                        board[i,j-1] = temp;
                        break;
                    }
                }
            }
        }

        if (orientation == "up") {
            for (int i = 0; i < 2; i++) {
                for (int j = 0; j < 4; j++) {
                    if (board[i,j].tag == "Player" && i > 0) {
                        GameObject temp = board[i,j];
                        board[i,j] = board[i-1,j];
                        board[i-1,j] = temp;
                        break;
                    }
                }
            }
        }

        if (orientation == "down") {
            for (int i = 0; i < 2; i++) {
                for (int j = 0; j < 4; j++) {
                    if (board[i,j].tag == "Player" && i < 1) {
                        GameObject temp = board[i,j];
                        board[i,j] = board[i+1,j];
                        board[i+1,j] = temp;
                        break;
                    }
                }
            }
        }
    }

    void flushBoard() {
        for (int i = 0; i < 2; i++) {
            for (int j = 0; j < 4; j++) {
                //Debug.Log(board[i,j]);
                board[i,j].transform.position = new Vector3((-3 + 2*j), ((i+1)*(-2)), 0);
            }
        }
    }
}
