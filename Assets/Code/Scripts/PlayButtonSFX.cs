using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonSFX : MonoBehaviour {
    public static PlayButtonSFX singleton { get; private set; }
    void Awake() {
        if(singleton != null && singleton != this) { Destroy(this.gameObject); } else { singleton = this; }
        DontDestroyOnLoad(this.gameObject);
    }

    public void play() {
        this.GetComponent<AudioSource>().PlayOneShot(this.GetComponent<AudioSource>().clip, 1f);
    }
}
