using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bird : MonoBehaviour
{
    public float jumpSpeed;
    public float rotatePower;
    public TextMeshPro scoreText;
    public AudioClip scoreSound;
    public GameObject endCard;
    public GameObject Pipe;
    public GameObject dayBackground;
    public GameObject nightBackground;
    public GameObject birdsr;
    public GameObject yellowBird;
    public GameObject blueBird;
    SpriteRenderer srDay;
    SpriteRenderer srNight;
    int score = 0;
    AudioSource source;


    Rigidbody2D rb;

    
    private void Start()
    {
        float randomBackground = Random.Range(0, 10);
        srDay = dayBackground.GetComponent<SpriteRenderer>();
        srNight = nightBackground.GetComponent<SpriteRenderer>();
        
        rb = GetComponent<Rigidbody2D>();
        source = gameObject.AddComponent<AudioSource>();
        print(randomBackground.ToString());
        if (randomBackground > 5 )
        {
            srDay.sortingOrder += 1;
            yellowBird.SetActive(true);
            blueBird.SetActive(false);
            
        }
        else
        {
            srNight.sortingOrder += 1;
            yellowBird.SetActive(false);
            blueBird.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }

        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotatePower);
    }

    void Die()
    {
        jumpSpeed = 0;
        rb.velocity = Vector2.zero;
        GetComponentInChildren<Animator>().enabled = false;
        Invoke("ShowMenu", 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score += 1;
        source.clip = scoreSound;
        source.Play();
        scoreText.text = score.ToString();
    }

    void ShowMenu()
    {
        print("the end");
        endCard.SetActive(true);
        scoreText.gameObject.SetActive(false);
    }

}

