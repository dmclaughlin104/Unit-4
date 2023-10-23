using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variables
    private Rigidbody playerRB;
    public float playerSpeed;
    private GameObject focalPoint;
    public GameObject powerUpIndicator;

    public bool hasPowerUp = false;
    private float powerUpStrength = 15.0f;


    // Start is called before the first frame update
    void Start()
    {
        //assigning variables at start
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        //player movement controller
        float forwardInput = Input.GetAxis("Vertical");
        playerRB.AddForce(focalPoint.transform.forward * playerSpeed *  forwardInput);

        //offsetting Power Up indicator from player position
        powerUpIndicator.transform.position = (transform.position - new Vector3(0, 0.6f, 0));
        
    }

    //method to check if player has a power up
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Power Up"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);

            //turn on power-up indicator
            powerUpIndicator.gameObject.SetActive(true);

            //start the power-up countdown
            StartCoroutine(PowerUpCountdownRoutine());
        }
    }

    //method to activate Power Up effects upon collision with enemy
    private void OnCollisionEnter(Collision collision)
    {
        //checking if player is colliding with the enemy and has a power up
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            //assigning enemy Rigidbody to variable
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();

            //working out the opposite direction from the player
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            //printing to screen
            Debug.Log("Collided with " + collision.gameObject.name + "with power up set to " + hasPowerUp);

            //implementing power up effect
            enemyRB.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }

    //method to set a limit on our power up time
    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);

        Debug.Log("Power Up is " + hasPowerUp + " i.e. has ended");
    }


}
