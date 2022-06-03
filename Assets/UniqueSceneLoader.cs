using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Extension of SceneLoader
public class UniqueSceneLoader : SceneLoader {

    // sets the anim of the SceneFader object to start the fade and switches scenes
    protected override IEnumerator FadeIntoScene() {
        yield return new WaitForSeconds(2f); //delayed
        anim.SetTrigger("start");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneToLoad);
    }

}
