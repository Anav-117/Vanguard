using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject musicPausebutton;
    public Text txt;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        txt.text = MoveTile.Score.ToString();

        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null) {
                if (hit.collider.gameObject.tag == "Home" && !MoveTile.Paused) {
                    MoveTile.Paused = false;
                    SceneManager.LoadScene("MainMenuState");
                }
                if (hit.collider.gameObject.tag == "Pause" && !MoveTile.Paused) {
                    MoveTile.Paused = true;
                    pauseScreen.transform.Translate(0, -9f, 0);
                }
                if (hit.collider.gameObject.tag == "Play") {
                    MoveTile.Paused = false;
                    pauseScreen.transform.Translate(0, 9f, 0);
                }
                if (hit.collider.gameObject.tag == "MusicOff") {
                    musicPausebutton.GetComponent<AudioSource>().volume = 0f;
                    musicPausebutton.transform.Translate(0, -10f, 0);
                }
                else if (hit.collider.gameObject.tag == "MusicOn") {
                    musicPausebutton.GetComponent<AudioSource>().volume = 1f;
                    musicPausebutton.transform.Translate(0, 10f, 0);
                }
            }
            
        }
    }
}
