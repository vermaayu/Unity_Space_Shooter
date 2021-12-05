using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed = 20f;

    [SerializeField]
    private GameObject _explosionPrefab;

    private SpawnManager _spawnManager;

    private void Start()
    {
        _spawnManager = FindObjectOfType<SpawnManager>();
        Vector3 asteroidSpawn = new Vector3(0, 7, 0);
        transform.SetPositionAndRotation(asteroidSpawn, Quaternion.identity);
    }

    void Update()
    {
        if (transform.position.y > 2)
        {
            transform.Translate(Vector3.down * 1 * Time.deltaTime);
        }

        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Laser"))
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(this.gameObject, 1f);
            Debug.Log("In SpawnManager");
            _spawnManager.StartSpawning();
            

        }
    }
}
