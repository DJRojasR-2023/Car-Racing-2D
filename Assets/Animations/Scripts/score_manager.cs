using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_manager : MonoBehaviour
{
    public int score = 0;
    // Start is called before the first frame update
    public Text scoreText;
    void Start()
    {
        StartCoroutine(Score());
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }
    IEnumerator Score()
    {
        while (true) 
        {
            yield return new WaitForSeconds(0.8f);
            score = score + 1;
            Debug.Log("Score: " + score);
        }
        
    }
}
