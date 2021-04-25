using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSizeControl : MonoBehaviour
{
    private Transform tf;
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    void Update()
    {
        tf.Translate(Vector2.up * Time.deltaTime * 0.1f);
    }
}
