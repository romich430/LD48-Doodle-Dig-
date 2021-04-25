using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform tf;
    private Vector2 center;

    void Start()
    {
        tf = GetComponent<Transform>();
        center = tf.position;
    }

    void Update()
    {
        tf.position = new Vector2((tf.position.x + Mathf.Sin(Time.time * 20f) * 0.005f), tf.position.y);
    }
}
