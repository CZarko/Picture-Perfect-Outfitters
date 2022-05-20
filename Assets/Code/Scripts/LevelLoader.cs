using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    //Scene scene = SceneManager.GetActiveScene();

    //void Awake() {
        //DontDestroyOnLoad(this.gameObject);
    //}

    // function to load proper scene using scenename, implemented to reduce amount of typing for public click functions
    void LoadScene(string sceneName) { SceneManager.LoadScene(sceneName); }

    // functions that are only ever called by on click methods
    public void LoadMenu() { LoadScene("Menu"); }
    public void LoadMain() { LoadScene("Main"); }
    public void LoadGameOver() { LoadScene("GameOver"); }
    public void LoadWin() { LoadScene("Win"); }
    public void LoadCredits() { LoadScene("Credits"); }
    public void Quit() { Application.Quit(); }

}
