using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeakerManager : MonoBehaviour {

    public Image textBox;
    public Text speakerText;
    private Queue<string> speech;

    public bool active;

    // Start is called before the first frame update
    void Start() {
        textBox.enabled = false; // make sure textbox is not already active
        speech = new Queue<string>(); // instantiate the speech Queue
    }

    public void Begin(string[] dialogue) {
        active = true;
        textBox.enabled = true; // make textbox appear
        speech.Clear(); // preps queue
        foreach(string s in dialogue) { speech.Enqueue(s); } // add each sentence in dialogue array to queue
        Next(); // output next sentence
    }

    public void Next() {
        if(speech.Count == 0) { End(); return; } // if speech queue is empty, speaker is done, call end
        string s = speech.Dequeue(); // fetch and store next string to be written
        StopAllCoroutines(); // prevent any previous coroutines from interfering
        StartCoroutine(TypeWriter(s)); // start TypeWriter coroutine which will print one letter at a time
    }

    IEnumerator TypeWriter(string s) {
        speakerText.text = ""; // clear the speaker text from previous output
        foreach(char c in s.ToCharArray()) { speakerText.text += c; yield return new WaitForSeconds(0.05f); } // add every char one at a time with some delay to speakerText
    }

    private void End() {
        active = false;
        textBox.enabled = false; // dissappear text box
        speakerText.text = ""; // ensures there is no residual text
    }
}
