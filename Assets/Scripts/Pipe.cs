using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if(transform.position.x < -6)
        {
            transform.position = new Vector3(6, transform.position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
