using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _enemySpeed = 3.0f;

    private Player _player;

    private Animator _anim;

    private AudioSource _audioSource;
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _audioSource = GetComponent<AudioSource>();
        
        if (_player == null)
        {
            Debug.LogError("The player component is null");
        }

        _anim = GetComponent<Animator>();

        if (_anim == null)
        {
            Debug.LogError("The animator is null");
        }

    }

    void Update()
    {
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);

        if (transform.position.y <= -7.0f)
        {
            float randomX = Random.Range(-9.0f, 9.0f);
            transform.position = new Vector3(randomX, 6, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit : " + other.transform.name);

        if (other.transform.tag == "Player")
        {
            //Damage Player health -= 1;
            //other.transform.GetComponent<Player>().Damage();

            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }
            _enemySpeed = 0;
            _anim.SetTrigger("OnEnemyDeath");
            _audioSource.Play();
            Destroy(this.gameObject, 2f);
            
        }
        else if (other.transform.CompareTag("Laser"))
        {
            //Player player = GameObject.Find("Player").GetComponent<Player>();-------------------- Too expensive => Make global.
            if (_player != null)
            {
                _player.ScoreAdd(Random.Range(1, 10));
            }
            _enemySpeed = 0;
            _anim.SetTrigger("OnEnemyDeath");
            _audioSource.Play();
            Destroy(other.gameObject);
            Destroy(this.gameObject, 0.8f);
            

        }
    }
}