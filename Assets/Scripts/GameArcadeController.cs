using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameArcadeController : MonoBehaviour {

    public int playerLife { get; private set; }

    public int gamePoints { get; private set; }

    public int pointsEnemyDestroyed = 10;

    public int pointsBoxPainted = 5;

    public static GameArcadeController Instance { get; private set; }

    void Awake() {
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            ResetGame();
        } else {
            Destroy(gameObject);
        }
    }

    public void ResetGame() {
        playerLife = 100;
        gamePoints = 0;
    }

    public void EnemyDestroyed() {
        gamePoints = gamePoints + pointsEnemyDestroyed;
    }

    public void BoxPainted() {
        gamePoints = gamePoints + pointsBoxPainted;
    }

    public void EnemyDamage() {
        playerLife = playerLife - 10;
    }
	
}
