using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private int _powerUpSpeed = 3;

    //ID for powerups 
    [SerializeField]  // powerupID = { 0 -> Trple Shot, 1 -> Speed, 2 -> Shield}
    private int powerupID;

    [SerializeField]
    private AudioClip _powerAudio;
    void Update()
    {
        transform.Translate(Vector3.down * _powerUpSpeed * Time.deltaTime);

        if (transform.position.y <= -7.0f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(_powerAudio, transform.position);
        if (collision.CompareTag("Player"))
        {
            Player player = collision.transform.GetComponent<Player>();
            if (player !=null)
            {
                switch(powerupID)
                {
                    case 0:
                        player.TripleShot();
                        break;

                    case 1:
                        Debug.Log("Collected Speed Boost");
                        player.SpeedBoost();
                        break;

                    case 2:
                        Debug.Log("Collected Speed Boost");
                        player.Shield();
                        break;

                    default:
                        break;
                }
            }
            Destroy(this.gameObject);
        }
    }
}