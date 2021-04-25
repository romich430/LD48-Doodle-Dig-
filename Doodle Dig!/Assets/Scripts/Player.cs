using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float MaxPos = 0;
    public Transform transform;
    public Rigidbody2D rb;
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    private Vector2 CameraBorders;
    public Text score;
    public Text highscoreText;
    private float highscore = 0;

    public AudioClip sound;
    private float volume = 0.5f;
    public AudioSource audio;
    
    void Start()
    {
        highscoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
        highscore = PlayerPrefs.GetInt("Highscore");
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        CameraBorders = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (highscore < MaxPos)
        {
            highscore = MaxPos;
            PlayerPrefs.SetInt("Highscore", (int)highscore);
            highscoreText.text = highscore.ToString("0");
        }
        if (transform.position.y < MaxPos)
        {
            MaxPos = transform.position.y;
        }
        score.text = (-MaxPos).ToString("0") + "m";
        if (transform.position.x < -CameraBorders.x)
        {
            transform.position = new Vector2(CameraBorders.x, transform.position.y);
        }
        if (transform.position.x > CameraBorders.x)
        {
            transform.position = new Vector2(-CameraBorders.x, transform.position.y);
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            rb.AddForce(Vector2.left * speed * Time.deltaTime);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            rb.AddForce(Vector2.right * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Block"))
        {
            other.gameObject.GetComponent<Block>().Breaking();
            rb.velocity = new Vector2(0f, jumpForce);
            audio.PlayOneShot(sound, volume);
        }
        if (other.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("StartingScreen");
        }
    }

}
