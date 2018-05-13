using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterCreate : MonoBehaviour {

    public int waitTime = 5;

	void Start () {
        Destroy(gameObject, waitTime);
	}
}
