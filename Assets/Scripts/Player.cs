using System.Collections;
using UnityEngine;
public class Player : MonoBehaviour {
    public static int ScoreCount = 0;
    public float speed = 15f;
    public float mapWidth = 5f;
    private Rigidbody2D rb;
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
    }
    void FixedUpdate () {
        float x = Input.GetAxis ("Horizontal") * Time.fixedDeltaTime * speed;
        Vector2 newPosition = rb.position + Vector2.right * x;
        newPosition.x = Mathf.Clamp (newPosition.x, -mapWidth, mapWidth);
        rb.MovePosition (newPosition);
    }
    void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Block") {
            FindObjectOfType<GameManager> ().EndGame ();
        }
    }
}