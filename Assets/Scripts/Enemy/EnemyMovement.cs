using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;

    void Awake () {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }

    void Update () {
        if(enemyHealth.currentHealth > 0 && GameArcadeController.Instance.playerLife > 0) {
            nav.SetDestination (player.position);
        } else {
            nav.enabled = false;
        }
    }
}
