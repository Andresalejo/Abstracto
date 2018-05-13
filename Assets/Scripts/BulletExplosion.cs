using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : BoxColorCollision {

    public bool usePhysics = true;
    public float colliderThickness = 0.1f;
    public float vertexPrecision = 0.01f;
    public Shader shader;
    public Color color;

    private Vector3 newVertex;
    private Vector3 lastVertex;

	private void Start() {
        changeBoxColor(color);
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == AllTags.TERRAIN) {
            collision.gameObject.GetComponent<BoxColorCollision>().changeBoxColor(color);
            GameArcadeController.Instance.BoxPainted();
            Destroy(gameObject);
        } else if (collision.gameObject.tag == AllTags.ENEMY) {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(50, collision.transform.position);
            Destroy(gameObject);
        } else {
            Destroy(gameObject, 2.0f);
        }
    }
}
