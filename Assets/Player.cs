using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
    BUILD,
    PLAY
}

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    
    public float force;
    public GameState state = GameState.BUILD;

    public Vector2 mouseStart;
    public Vector2 mousePos;
    public Vector2 mouseEnd;

    private Vector2 forceDir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // rb.AddForce(new Vector2(force, force), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(state == GameState.PLAY) {
            if(Input.GetMouseButtonDown(0)) {
                mouseStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            else if(Input.GetMouseButton(0)) {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            else if(Input.GetMouseButtonUp(0)) {
                mouseEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                forceDir = (mouseEnd - mouseStart);
                // Debug.Log(forceDir);
                rb.AddForce(-forceDir, ForceMode2D.Impulse);
            }
        }
    }

    private void FixedUpdate() {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy") {
            foreach(ContactPoint2D point2D in other.contacts) {
                Debug.DrawLine(point2D.point, point2D.point + point2D.normal, Color.red, 10f);
                if(point2D.normal.y > .5f) {
                    Destroy(other.gameObject);
                }

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Catapult") {
            Debug.Log("Start catapulting or something");
        }
    }
}
