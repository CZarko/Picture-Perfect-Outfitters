using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour {

    private string[] dialogue;
    public bool init = false;

    public void Start() {
        Reset();
    }

    public void Reset() {
        dialogue = FindObjectOfType<DialogueGenerator>().Generate();
        FindObjectOfType<SpeakerManager>().End();
    }

    void OnMouseDown() {
      if(!FindObjectOfType<SpeakerManager>().active)
          FindObjectOfType<SpeakerManager>().Begin(dialogue);
      else
          FindObjectOfType<SpeakerManager>().Next();
    }

    void Update() {
        if(init && !FindObjectOfType<SpeakerManager>().active)
            FindObjectOfType<SpeakerManager>().Begin(dialogue);
        init = false;
    }
}
