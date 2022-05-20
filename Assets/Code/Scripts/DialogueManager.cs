using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

    private Queue<string> sentences; // queue for ouptut creation

    // Start is called before the first frame update
    void Start() {
        sentences = new Queue<string>(); // queue for output assignment
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Begin(Dialogue dialogue) {
        Debug.Log("Starting " + dialogue.name + "\'s dialogue"); // public function to be called for beginning to dequeue and print
    }

}
