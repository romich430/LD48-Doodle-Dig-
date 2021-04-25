using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    public Vector2 screenBounds;
    private Transform transform;
    public float speed;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y <= (Camera.main.transform.position.y - 2f * screenBounds.y))
        {
            transform.position = new Vector2(transform.position.x, (Camera.main.transform.position.y + 2f * screenBounds.y));
        } 
        if (transform.position.y > (Camera.main.transform.position.y + 2.1f * screenBounds.y))
        {
            transform.position = new Vector2(transform.position.x, (Camera.main.transform.position.y - 1.9f * screenBounds.y));
        }
    }
}
