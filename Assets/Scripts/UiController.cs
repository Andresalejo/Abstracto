using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour {

    public Text playerPoints;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdatePlayerPoints();
	}

    private void UpdatePlayerPoints() {
        if(playerPoints != null) {
            playerPoints.text = StringUtils.ZeroToLeft(GameArcadeController.Instance.gamePoints);
        }
    }
}
