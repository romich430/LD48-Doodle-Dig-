using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    private Transform transform;
    public float speed;
    private Transform player;

    void Start()
    {
        player = GameObject.Find("Driller").GetComponent<Transform>();
        transform = GetComponent<Transform>();    
    }

    void Update()
    {
        if (player.position.y > transform.position.y)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else if (player.position.y <= transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
