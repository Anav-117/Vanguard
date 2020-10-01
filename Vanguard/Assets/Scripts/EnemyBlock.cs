using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBlock : MonoBehaviour
{ 
    private BoxCollider2D collisionbox;
    private bool condition;
    public TextAsset score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!MoveTile.Paused) {
            transform.Translate(0, -EnemySpawner.speed * Time.deltaTime, 0);
        }

        if (transform.position.y < -5) {
            Destroy(gameObject);
            PlayerPrefs.SetInt("Score", MoveTile.Score);
            SceneManager.LoadScene("MainMenuState");
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        condition = ((other.tag == "Green" && gameObject.tag == "EGreen") || (other.tag == "Blue" && gameObject.tag == "EBlue") || (other.tag == "Red" && gameObject.tag == "ERed"));
		if (condition) {
            Destroy(gameObject);
            MoveTile.Score += 1;
        }
        else {
            Color tmp = other.GetComponent<SpriteRenderer>().color;
            tmp.a = 0f;
            other.GetComponent<SpriteRenderer>().color = tmp;
            collisionbox = other.GetComponent<BoxCollider2D>();
            Destroy(collisionbox);
            Destroy(gameObject);
        }
        
	}
}
