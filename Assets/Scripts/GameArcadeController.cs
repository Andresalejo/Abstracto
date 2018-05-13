using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameArcadeController : MonoBehaviour {

    public int playerLife { get; private set; }
    public int gamePoints { get; private set; }
    public float timeCount { get; private set; }

    public int pointsEnemyDestroyed = 10;
    public int pointsBoxPainted = 5;
    public int damageEnemy = 20;
    public bool pause = false;
    public bool endGame = false;
    public BoxColorCollision[] boxColorCollisions;
    public GameObject player;

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

	private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        boxColorCollisions = FindObjectsOfType<BoxColorCollision>();
	}

	private void Update() {
        if(Input.GetButtonDown("Cancel")) {
            pause = !pause;
            if (!pause) {
                Time.timeScale = 1f;
            } else {
                Time.timeScale = 0f;
            }
        }
	}

	private void FixedUpdate() {
        if (!pause) {
            timeCount = timeCount + Time.deltaTime;
        }
	}

	public void ResetGame() {
        playerLife = 100;
        gamePoints = 0;
        timeCount = 0;
    }

    public void EnemyDestroyed() {
        gamePoints = gamePoints + pointsEnemyDestroyed;
    }

    public void BoxPainted() {
        gamePoints = gamePoints + pointsBoxPainted;
        CheckBoxesPainted();
    }

    public void EnemyDamage() {
        playerLife = playerLife - damageEnemy;
        Debug.Log(string.Concat("Vida: ", playerLife));
        if(playerLife < 0f) {
            FinishGame();
            PlayLoseMusic();
        }
    }

    public void CheckBoxesPainted() {
        bool thereAreUnPainted = false;
        foreach(BoxColorCollision box in boxColorCollisions) {
            if (!box.painted) {
                thereAreUnPainted = true;
            }
        }
        if(!thereAreUnPainted) {
            FinishGame();
            PlayWinMusic();
        }
    }

    public void FinishGame() {
        endGame = true;
        pause = true;
        player.GetComponent<FirstPersonController>().enabled = false;
        Time.timeScale = 0f;
    }

    public void PlayWinMusic() {
        
    }

    public void PlayLoseMusic() {

    }
	
}
