using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteController : MonoBehaviour {

    public SpriteRenderer spriteRenderer; // component of sprite that stores the image currently rendered
    public List<Sprite> sprites; // list of all sprites that controlled object can render, manually inserted via inspector
    private int i; // stores current index of the sprite being rendered from the sprites list

    //public bool modifiable; // can the user change this sprite during gameplay?
    //public string name; // name of the sprite type (i.e. is it the top, the body, the head, etc.)
    //public Text text; // output object that player can see the active name of the sprite from the list rendered ultimately

    // Start is called before the first frame update
    void Start() {
        spriteRenderer = this.GetComponent<SpriteRenderer>(); // fetch render component from sprite itself
        Reset();
    }

    public void Reset() {
         i = UnityEngine.Random.Range(0, sprites.Count); // set init index to a random in the range of the sprites list bounds
        ChangeSprite(i); // change the sprite to the sprite at that index
    }

    void ChangeSprite(int index) {
        try { // error trapping
            spriteRenderer.sprite = sprites[index]; // change the sprite to the sprites[index] sprite
            //if(modifiable) text.text = name + ": " + spriteRenderer.sprite.name; // if the object is modifiable then a text object should exist and therfore it should be updated
        } catch(MissingReferenceException) { Debug.LogError("The provided reference at index " + index + " is missing!"); } // error happened
    }

    public void NextSprite() { // function to increase index for calling on click
        i = (i+1)%sprites.Count; // modulo for index wrapping
        ChangeSprite(i);
    }

    public void PrevSprite() { // function to decrease index for calling on click
        if(--i < 0) i = sprites.Count-1; // decrease sprite and if below 0 wrap to end
        ChangeSprite(i);
    }

}
