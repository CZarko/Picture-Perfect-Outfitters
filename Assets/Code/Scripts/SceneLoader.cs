using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Developed by the following Tutorial
// https://www.youtube.com/watch?v=CE9VOZivb3I
public class SceneLoader : MonoBehaviour {
    public string sceneToLoad;
    protected Animator anim;

    // Start is called before the first frame update
    void Start() {
        anim = GameObject.Find("SceneFader").GetComponent<Animator>();
    }

    // function to be called externally, calls fade coroutine
    public void Load() {
        StartCoroutine(FadeIntoScene()); 
    }

    // sets the anim of the SceneFader object to start the fade and switches scenes
    protected virtual IEnumerator FadeIntoScene() {
        anim.SetTrigger("start");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneToLoad);
    }
}
