using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Temp based off Brackey's Dialogue System Tutorial on YouTube
//Going to Recreate after better understanding his method to fit our needs

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue; //stores dialogue data
    public GameObject textbox; // for storing text box prefab for instantiation

    private bool active = false; // flag to prevent dialogue from starting again

    // Start is called before the first frame update
    void Start() {
        
    }

}
