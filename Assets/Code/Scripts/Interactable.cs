using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    public Texture2D cursorTexture; // the INTERACT cursor texture
    void OnMouseEnter() {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit() {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
