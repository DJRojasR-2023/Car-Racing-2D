using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Moment : MonoBehaviour
{
    public Transform playertransform;
    public float speed = 0.5f;
    public float rotationspeed = 1f;

    public score_manager scoreValue;

    public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        movement();
        Clamp();



    }
    void movement()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playertransform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            playertransform.rotation = Quaternion.Lerp(playertransform.rotation, Quaternion.Euler(0, 0, 90), rotationspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playertransform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            playertransform.rotation = Quaternion.Lerp(playertransform.rotation, Quaternion.Euler(0, 0, 270), rotationspeed * Time.deltaTime);
        }
        if (playertransform.rotation.z != 90)
        {
            playertransform.rotation = Quaternion.Lerp(playertransform.rotation, Quaternion.Euler(0, 0, 180), 10f * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playertransform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            playertransform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }
    }
    void Clamp()
    {
        Vector3 pos = playertransform.position;
        pos.x = Mathf.Clamp(pos.x, -1.7f, 1.5f);
        playertransform.position = pos;

        Vector3 pos1 = playertransform.position;
        pos1.y = Mathf.Clamp(pos1.y, -3.5f, 3.5f);
        playertransform.position = pos1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cars")
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
        else if (collision.gameObject.tag == "Coin")
        {
            scoreValue.score += 10;
            Destroy(collision.gameObject);
        }

    }
   

}