using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMode : MonoBehaviour
{
    public GameObject catapult;
    public Player player;

    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;

        if(Input.GetMouseButtonDown(0) && player.state == GameState.BUILD) {
            Instantiate(catapult, mousePos, transform.rotation);
        }

        if(player.state == GameState.PLAY) {
            sprite.enabled = false;
        }
        else {
            sprite.enabled = true;
        }
    }
}
