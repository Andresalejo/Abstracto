using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;


    Animator anim;
    GameObject player;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    void Awake () {
        player = GameObject.FindGameObjectWithTag ("Player");
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
    }

	private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject == player) {
            playerInRange = true;
        }
	}

	private void OnCollisionExit(Collision collision) {
        if (collision.gameObject == player) {
            playerInRange = false;
        }
	}

    void Update () {
        timer += Time.deltaTime;
        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0) {
            Attack ();
        }

        if(GameArcadeController.Instance.playerLife <= 0) {
            anim.SetTrigger ("PlayerDeath");
        }
    }


    void Attack () {
        timer = 0f;
        if(GameArcadeController.Instance.playerLife > 0) {
            anim.SetBool("Attack", true);
            GameArcadeController.Instance.EnemyDamage();
        } else {
            anim.SetBool("Attack", false);
        }
    }
}
