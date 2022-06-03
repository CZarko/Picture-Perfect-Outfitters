using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditManager : MonoBehaviour {

    [TextArea(3,10)]
    public string[] dialogue;

    public Text creditText;
    private Queue<string> credits;

    // Start is called before the first frame update
    void Start() {
        credits = new Queue<string>(); // instantiate the credit Queue
        StartCoroutine(DelayedBegin()); // start the coroutine that will start the credits after a delay
    }

    IEnumerator DelayedBegin() {
        yield return new WaitForSeconds(0.5f); // wait for a couple seconds
        Begin(dialogue); // begin the credits
    }

    public void Begin(string[] dialogue) {
        credits.Clear(); // preps queue
        foreach(string s in dialogue) { credits.Enqueue(s); } // add each sentence in dialogue array to queue
        Next(); // output next sentence
    }

    public void Next() {
        if(credits.Count == 0) { End(); return; } // if credit queue is empty, speaker is done, call end
        string s = credits.Dequeue(); // fetch and store next string to be written
        StopAllCoroutines(); // prevent any previous coroutines from interfering
        StartCoroutine(TypeWriter(s)); // start TypeWriter coroutine which will print one letter at a time
    }

    IEnumerator TypeWriter(string s) {
        creditText.text = ""; // clear the credit text from previous output
        foreach(char c in s.ToCharArray()) { creditText.text += c; yield return new WaitForSeconds(0.05f); } // add every char one at a time with some delay to creditText
        yield return new WaitForSeconds(2f); // wait a couple seconds
        Next(); // begin next
    }

    private void End() {
        creditText.text = ""; // ensures there is no residual text
        SceneManager.LoadScene("Menu"); // exit to main menu
    }
}
