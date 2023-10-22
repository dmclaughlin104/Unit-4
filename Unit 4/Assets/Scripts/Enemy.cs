using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //variables & objects
    private Rigidbody enemyRB;
    private GameObject player;
    public float speed = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();//assigning Rigidbody component
        player = GameObject.Find("Player");//assigning Player to variable

    }

    // Update is called once per frame
    void Update()
    {
        //determining direction toward player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        //moving enemy toward player
        enemyRB.AddForce(lookDirection * speed);


        //destroy enemy if they fall off platform
        if (transform.position.y < -20.0f)
        {
            Destroy(gameObject);
        }
        
    }
}
