using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShotPlayer : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    [Range(2f, 40f)] public float speed = 20f;
    public Color[] colors;
    public Button buttonColor;
    private int indexColor = 0;

	private void Start() {
        updateColorUI();
	}

	void Update() {
        if (Input.GetMouseButtonDown(0)){
            Fire();
        }
        if (Input.GetAxis(AllTags.INPUT_MOUSE_SCROLL) > 0f) {
            colorForward();
        } else if (Input.GetAxis(AllTags.INPUT_MOUSE_SCROLL) < 0f) {
            colorBackward();
        }
    }

    private void colorForward() {
        indexColor++;
        if(indexColor >= colors.Length) {
            indexColor = 0;
        }
        updateColorUI();
    }

    private void colorBackward() {
        indexColor--;
        if (indexColor < 0) {
            indexColor = colors.Length - 1;
        }
        updateColorUI();
    }

    private void Fire() {
        bulletPrefab.GetComponent<BulletExplosion>().color = colors[indexColor];
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * speed;
    }

    private void updateColorUI() {
        Debug.Log(string.Concat("Index color: ", indexColor));
        if (buttonColor != null) {
            ColorBlock colorBlock = buttonColor.colors;
            colorBlock.normalColor = colors[indexColor];
            buttonColor.colors = colorBlock;
        }
    }
}
