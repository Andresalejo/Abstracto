using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColorCollision : MonoBehaviour {

    private Renderer renderer;
    private bool painted = false;

    void Awake() {
        renderer = GetComponent<Renderer>();
    }

    public void changeBoxColor(Color color) {
        painted = true;
        renderer.material.color = color;
    }
}
