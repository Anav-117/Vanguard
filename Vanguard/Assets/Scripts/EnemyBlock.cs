using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBlock : MonoBehaviour
{ 
    private BoxCollider2D collisionbox;
    private bool condition;
    public GameObject EDSound;
    public GameObject PDSound;
    private bool Destroy;
    private _2dxFX_DestroyedFX FX_DestroyedFX;
    private bool des;
    private _2dxFX_DesintegrationFX Desintegrate;
    private

    // Start is called before the first frame update
    void Start()
    {
        EDSound = GameObject.Find("EDSound");
        PDSound = GameObject.Find("PDSound");
        Destroy = false;
        FX_DestroyedFX = GetComponent<_2dxFX_DestroyedFX>();
        des = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!MoveTile.Paused && !Destroy) {
            transform.Translate(0, -EnemySpawner.speed * Time.deltaTime, 0);
        }

        if (transform.position.y < -5) {
            Destroy(gameObject);
            if (PlayerPrefs.GetInt("Score") < MoveTile.Score) {
                PlayerPrefs.SetInt("Score", MoveTile.Score);
            }
            SceneManager.LoadScene("MainMenuState");
        }

        if (des) {
            Desintegrate.Desintegration += 2.0f * Time.deltaTime;
            Desintegrate._Alpha -= 1.0f * Time.deltaTime;
            if (Desintegrate.Desintegration >= 1) {
                Desintegrate._Alpha = 0f;
                Destroy(gameObject);
                des = false;
            }
        }

        if (Destroy) {
            FX_DestroyedFX.Destroyed += 2.0f * Time.deltaTime;
            if (FX_DestroyedFX.Destroyed >= 1) {
                Destroy(gameObject);
                Destroy = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        condition = ((other.tag == "Green" && gameObject.tag == "EGreen") || (other.tag == "Blue" && gameObject.tag == "EBlue") || (other.tag == "Red" && gameObject.tag == "ERed"));
		if (condition) {
            EDSound.GetComponent<AudioSource>().Play();
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(GetComponent<Collider2D>());
            Destroy = true;
            //Destroy(gameObject);
            MoveTile.Score += 1;
        }
        else if (other.tag == "Player") {
            PDSound.GetComponent<AudioSource>().Play();
            if (PlayerPrefs.GetInt("Score") < MoveTile.Score) {
                PlayerPrefs.SetInt("Score", MoveTile.Score);
            }
            SceneManager.LoadScene("MainMenuState");
        }
        else {
            PDSound.GetComponent<AudioSource>().Play();
            Destroy = true;
            des = true;
            Desintegrate = other.GetComponent<_2dxFX_DesintegrationFX>();
            //Debug.Log(Desintegrate);
            Color tmp = other.GetComponent<SpriteRenderer>().color;
            tmp.a = 0f;
            collisionbox = other.GetComponent<BoxCollider2D>();
            Destroy(collisionbox);
            //Destroy(gameObject);
        }
        
	}
}
