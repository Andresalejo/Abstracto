using UnityEngine;
using System.Collections;

public class ShotPlayer : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    [Range(2f, 20f)] public float speed = 10;
    public Color[] colors;

    void Update() {
        if (Input.GetMouseButtonDown(0)){
            Fire();
        }
    }

    private void Fire() {
        int colorIndex = Random.Range(0, colors.Length);
        bulletPrefab.GetComponent<BulletExplosion>().color = colors[colorIndex];
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * speed;
    }
}
