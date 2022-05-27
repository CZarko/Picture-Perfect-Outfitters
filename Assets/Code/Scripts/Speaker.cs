using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour {
    [TextArea(3,10)]
    public string[] dialogue;

    void OnMouseDown() {
      if(!FindObjectOfType<SpeakerManager>().active)
          FindObjectOfType<SpeakerManager>().Begin(dialogue);
      else
          FindObjectOfType<SpeakerManager>().Next();
    }
}
