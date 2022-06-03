using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Made from the following Tutorial
// https://www.youtube.com/watch?v=FgWVW2PL1bQ&list=PLF3xhACXvo9NIXQZZFyQIAyIe9qZImK74&index=2
public class TextWobble : MonoBehaviour {
    private TMP_Text textMesh;
    private Mesh mesh; 
    private Vector3[] vertices;

    // Start is called before the first frame update
    void Start() {
        textMesh = GetComponent<TMP_Text>(); // fetch the text mesh component
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
}
