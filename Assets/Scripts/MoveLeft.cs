using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 20; // nopeus jolla objekti liikkuu
    private PlayerController playerControllerScript; // viittaus playercontrollerscriptiin
    private float leftBound = -15; // kohta jossa objektit tuhotaan kun menee liian vasemmalle

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); // etsitään pelihahmo nimeltä "player" ja playercontroller skripti
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false) // jos peli ei ole ohi liikutetaan objektia vasemmalle
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed); // liikutetaan objektia vasemmalle ajan mukaan
        } 

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle")) // jos objekti "obstacle" menee liian vasemmalle se tuhotaan
        {
            Destroy(gameObject);
        }
    }
}
