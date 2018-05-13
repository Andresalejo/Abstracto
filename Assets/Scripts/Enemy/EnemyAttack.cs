using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 3f;
    public int attackDamage = 10;


    Animator anim;
    GameObject player;
    EnemyHealth enemyHealth;
    float timer;


    void Awake () {
        player = GameObject.FindGameObjectWithTag ("Player");
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
    }

	private void OnCollisionStay(Collision collision) {
        if (collision.gameObject == player) {
            if(timer >= timeBetweenAttacks && enemyHealth.currentHealth > 0) {
                GameArcadeController.Instance.EnemyDamage();
                timer = 0f;
            }
        }
	}

    void Update () {
        timer += Time.deltaTime;
        float playerDistance = Vector3.Distance(transform.position, player.transform.position);
        if(playerDistance < 2.5f) {
            Attack();
        } else {
            anim.SetBool("Attack", false);
        }

        if(GameArcadeController.Instance.playerLife <= 0) {
            anim.SetTrigger ("PlayerDeath");
        }
    }


    void Attack () {
        if(GameArcadeController.Instance.playerLife > 0) {
            anim.SetBool("Attack", true);
        } else {
            anim.SetBool("Attack", false);
        }
    }
}
