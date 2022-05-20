using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

    public string name; // name of dialouge sender

    [TextArea(3,10)]
    public string[] sentences; // dialogue to be manually entered through inspector
    // we are beginning to develop a script that creates randomized dialogue instead
    // that includes context clues for finding the correct outfit pieces

}
