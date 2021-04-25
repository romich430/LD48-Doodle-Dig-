using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Block") || other.CompareTag("Light") || other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("StartingScreen");
        }
    }
}
