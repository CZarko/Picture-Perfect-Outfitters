using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CreditManager : MonoBehaviour {

    [TextArea(3,10)]
    public string[] dialogue;

    public AudioClip[] clips;
    private AudioSource audioSource;

    private TMP_Text textMesh; // textmesh of credit text
    private Mesh mesh; // mesh of credit text
    private Vector3[] vertices; // vertices of credit text
    private Queue<string> credits;

    // Start is called before the first frame update
    void Start() {
        credits = new Queue<string>(); // instantiate the credit Queue
        audioSource = this.GetComponent<AudioSource>(); // fetch audio source
        TMP_Text[] tmps = GetComponentsInChildren<TMP_Text>();
        foreach(TMP_Text tmp in tmps) textMesh = tmp;
        StartCoroutine(DelayedBegin()); // start the coroutine that will start the credits after a delay
    }

    // Update is called once per frame
    void Update() {
        textMesh.ForceMeshUpdate(); // update text mesh
        mesh = textMesh.mesh; // get current mesh
        vertices = mesh.vertices; // get current vertices
        for(int i = 0; i < textMesh.textInfo.characterCount; ++i) { // for every character in the text
            TMP_CharacterInfo c = textMesh.textInfo.characterInfo[i]; // get char info
            
            int index = c.vertexIndex; // get vertex index on the mesh

            Vector3 offset = Wobble(Time.time + i); // calculate wobbles
            vertices[index] += offset; // apply offset to all four vertices of char 
            vertices[index+1] += offset;
            vertices[index+2] += offset;
            vertices[index+3] += offset;
        }
        mesh.vertices = vertices; // update mesh vertices
        textMesh.canvasRenderer.SetMesh(mesh); // update renderer
    }

    Vector2 Wobble(float time) {
        return new Vector2(Mathf.Sin(time*3.3f), Mathf.Cos(time*2.5f)); // basic wobbling
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
        textMesh.SetText(""); // clear the credit text from previous output
        audioSource.clip = clips[Random.Range(0, clips.Length)]; // pick random sound effect
        audioSource.Play(); // play sound effect
        foreach(char c in s.ToCharArray()) { 
            // if either of the following two characters show up richtext change color
            // and skip to next loop with no delay
            if(c=='%') {textMesh.SetText(textMesh.text + "<color=#00B7EB>"); continue;}
            if(c=='$') {textMesh.SetText(textMesh.text + "<color=#424242>"); continue;}
            textMesh.SetText(textMesh.text+c); // update text with char
            yield return new WaitForSeconds(0.05f); 
        } // add every char one at a time with some delay to creditText
        yield return new WaitForSeconds(2f); // wait a couple seconds
        Next(); // begin next
    }

    private void End() {
        textMesh.SetText(""); // ensures there is no residual text
        SceneManager.LoadScene("Menu"); // exit to main menu
    }
}
