using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour {

    public Text playerPoints;
    public Text timerText;
    public Button lifeBar;
    private float x;
    private float y;
    // Use this for initialization
    void Start () {
        x = lifeBar.image.rectTransform.sizeDelta.x;
        y = lifeBar.image.rectTransform.sizeDelta.y;

    }
	
	// Update is called once per frame
	void Update () {
        UpdatePlayerPoints();
        UpdateTime();
        UpdateLifeBar();

	}


    private void UpdateLifeBar()
    {
        if (lifeBar != null) {
            int playerLife = GameArcadeController.Instance.playerLife;
            lifeBar.image.rectTransform.sizeDelta = new Vector2((playerLife * x) / 100, y);
            if(playerLife <= 0)
            {
                lifeBar.gameObject.SetActive(false);
            } else
            if(playerLife < 45) {
                ColorBlock colorBlock = lifeBar.colors;
                colorBlock.normalColor = Color.red;
                lifeBar.colors = colorBlock;
            }
        }

    }


    private void UpdatePlayerPoints() {
        if(playerPoints != null) {
            playerPoints.text = StringUtils.ZeroToLeft(GameArcadeController.Instance.gamePoints);
        }
    }

    private void UpdateTime(){
        if(timerText != null) {
            timerText.text = StringUtils.SecondsToHours(GameArcadeController.Instance.timeCount);
        }
    }
}
