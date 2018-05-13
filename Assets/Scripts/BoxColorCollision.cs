using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColorCollision : MonoBehaviour {

    private Renderer renderer;
    public bool painted { get; private set; }

    void Awake() {
        renderer = GetComponent<Renderer>();
    }

    public void changeBoxColor(Color color) {
        painted = true;
        renderer.material.color = color;
    }
}
