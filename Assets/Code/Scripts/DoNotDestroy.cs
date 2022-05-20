using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour {
    public static DoNotDestroy Instance { get; private set; }
    void Awake() {
        if(Instance != null && Instance != this) { Destroy(this.gameObject); } else { Instance = this; }
        DontDestroyOnLoad(this.gameObject);
    }
}
