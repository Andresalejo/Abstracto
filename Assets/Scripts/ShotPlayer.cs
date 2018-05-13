using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ShotPlayer : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    [Range(2f, 40f)] public float speed = 20f;
    public Color[] colors;
    public Button buttonColor;
    public AudioClip disparo;
    private int indexColor = 0;
    AudioSource aSource;

    private void Start() {
        colors = AllTags.colors;
        UpdateColorUI();
        aSource = GetComponent<AudioSource>();

    }

	void Update() {
        if (Input.GetMouseButtonDown(0)){
            Fire();
        }
        if (Input.GetAxis(AllTags.INPUT_MOUSE_SCROLL) > 0f) {
            ColorForward();
        } else if (Input.GetAxis(AllTags.INPUT_MOUSE_SCROLL) < 0f) {
            ColorBackward();
        }
    }

    private void ColorForward() {
        indexColor++;
        if(indexColor >= colors.Length) {
            indexColor = 0;
        }
        UpdateColorUI();
    }

    private void ColorBackward() {
        indexColor--;
        if (indexColor < 0) {
            indexColor = colors.Length - 1;
        }
        UpdateColorUI();
    }

    private void Fire() {
        bulletPrefab.GetComponent<BulletExplosion>().color = colors[indexColor];
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * speed;
        aSource.Play();

    }

    private void UpdateColorUI() {
        if (buttonColor != null) {
            ColorBlock colorBlock = buttonColor.colors;
            colorBlock.normalColor = colors[indexColor];
            buttonColor.colors = colorBlock;
        }
    }
}
