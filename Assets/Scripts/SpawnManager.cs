using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab; // objekti joka luodaan
    private Vector3 spawnPos = new Vector3(25, 0, 0); // sijainti johon esteet luodaan
    private float startDelay = 2; // viive ensimmäisen esteen luomiseen
    private float repeatRate = 2; // aikaväli jolla esteitä luodaan
    private PlayerController playerControllerScript; // viittaus playercontroller skriptiin

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate); // kutsutaan spawnobstaclea säännöllisesti määritetyllä viiveellä ja aikavälillä
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); // etsitään pelaajaobjekti ja haetaan sen playercontroller skripti
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false) // luodaan uusi este jos peli ei ole ohi
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation); // luodaan uusi este
        }
    }
}
