using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obj;
    private Transform tf;
    public Vector2 ScreenBounds;
    public Vector2 center;
    public Vector2 Xborder;
    public Vector2 Yborder;
    public Camera cam;
    private float distance = 10f;

    void Start()
    {
        center = new Vector2(0f, 0f);
        tf = GetComponent<Transform>();
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        for (int i = 10; i > 0; i--)
        {
            tf.position = new Vector2(Random.Range(-2.75f, 2.75f), Random.Range(3f, -5f));
            Instantiate(obj[0], tf.position, Quaternion.identity);
        }
        tf.position = center;
        Spawn();
    }

    void Update()
    {
        if (cam.GetComponent<Transform>().position.y <= -distance)
        {
            Spawn();
            distance += 10f;
        }
    }

    void Spawn()
    {
        tf.position = new Vector2(tf.position.x, (tf.position.y - (2f * ScreenBounds.y)));
        center = tf.position;
        Xborder = new Vector2(tf.position.x - 2.75f, tf.position.x + 2.75f);
        Yborder = new Vector2(tf.position.y - 5f, tf.position.y + 3f);
        Vector2 PrevPos = tf.position;
        for (int i = 10; i > 0; i--)
        {
            tf.position = new Vector2(Random.Range(Xborder.x, Xborder.y), Random.Range(Yborder.x, Yborder.y));
            while (Vector2.Distance(tf.position, PrevPos) < 0.5f)
            {
                tf.position = new Vector2(Random.Range(Xborder.x, Xborder.y), Random.Range(Yborder.x, Yborder.y));
            }
            Instantiate(obj[0], tf.position, Quaternion.identity);
            if (Random.Range(0, 50) > 47)
            {
                tf.position = new Vector2(tf.position.x, (tf.position.y + 1f));
                Instantiate(obj[Random.Range(4, 8)], tf.position, Quaternion.identity);
            }
            PrevPos = tf.position;
        }
        tf.position = center;
        for (int i = Random.Range(0, 2); i > 0; i--)
        {
            tf.position = new Vector2(Random.Range(Xborder.x - 1f, Xborder.y + 1f), Random.Range(Yborder.x, Yborder.y));
            Instantiate(obj[Random.Range(1, 4)], tf.position, Quaternion.identity); ;
        }
        tf.position = center;
    }
}
