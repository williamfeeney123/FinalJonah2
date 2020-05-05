using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Moving : MonoBehaviour
{
    public float speed;
    public float hitNum;
    public Light light;
    public AudioSource audio;

   
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0f, speed, 0f) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0f, -speed, 0f) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed, 0f, 0f) * Time.deltaTime;
        }

        if(transform.position.y > 280 && Input.GetKey(KeyCode.Space))
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            light.color = Color.black;
           
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Friend")
        {

            Destroy(collision.gameObject.GetComponent<LighFlash>());
            hitNum++;
            collision.gameObject.GetComponent<Renderer>().material.color = Color.green;
            collision.gameObject.transform.localScale = new Vector2(.8f,.8f);
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            collision.gameObject.GetComponent<Light>().enabled = false;
            if (hitNum == 5)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
              
                Debug.Log("Change Color");
            }
            if (hitNum == 15)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.black;
                Debug.Log("Change Color");
            }
            if (hitNum == 20)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                light.color = Color.black;
            }

                Debug.Log("Your hitting me");
        }
        if (collision.gameObject.tag == "BIGBIRTHA")
        {
            Destroy(collision.gameObject.GetComponent<LighFlash>());
            hitNum++;
            Debug.Log("BIGBIRTHA");
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            collision.gameObject.transform.localScale = new Vector2(.8f, .8f);
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            collision.gameObject.GetComponent<Light>().enabled = false;
            Destroy(collision.gameObject.GetComponent<AudioSource>());
        }

        if (collision.gameObject.tag == "Win")
        {
            Debug.Log("win");
            SceneManager.LoadScene(1);
        }
    }
    }
