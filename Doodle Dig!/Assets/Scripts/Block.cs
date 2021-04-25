using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Transform tf;
    public int hardness = 1;
    public GameObject parts;

    public void Breaking()
    {
        if (hardness == 0)
        {
            StartCoroutine(Broken());
        }
        else
        {
            hardness--;
            StartCoroutine(Shaking());
        }
    }

    IEnumerator Shaking()
    {
        Transform tf = GetComponent<Transform>();
        Vector2 pos = tf.position;
        float Timer = 0.5f;
        while (Timer >= 0)
        {
            tf.position = new Vector2((tf.position.x + Random.Range(-0.1f, 0.1f)), (tf.position.y + Random.Range(-0.1f, 0.1f)));
            yield return null;
            tf.position = pos;
            Timer -= Time.deltaTime;
        }
    }

    IEnumerator Broken()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        parts.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        hardness = 2;
        Destroy(gameObject);
    }
}
