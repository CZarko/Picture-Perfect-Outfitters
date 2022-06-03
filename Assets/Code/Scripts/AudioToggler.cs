using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioToggler : MonoBehaviour {

    private AudioSource audioSource; // the component that controls the bg music
    public Image img; // the image of the button
    public Sprite unmuted; // the sprite that holds the unmuted graphic
    public Sprite muted; // the sprite that holds the muted graphic


    // Start is called before the first frame update
    void Start() {
        audioSource = GameObject.Find("AudioManager").GetComponent<AudioSource>(); // fetch the bg music audio source
        updateGraphic(); // set the mute graphic to the write status
    }

    private void updateGraphic() {
        if(!audioSource.mute) { img.sprite = unmuted; } else { img.sprite = muted; } // set the audio mute graphic based on audio source status
    }

    public void ToggleMute() { audioSource.mute = !audioSource.mute; updateGraphic(); } // toggle the mute property of the audio source and the graphic
}
