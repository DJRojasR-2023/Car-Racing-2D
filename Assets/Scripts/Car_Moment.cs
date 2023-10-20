using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Moment : MonoBehaviour
{
    public Transform cartransform;
    public float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        cartransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    { 
      cartransform.position -= new Vector3(0, speed * Time.deltaTime, 0);
      if(cartransform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }
}
