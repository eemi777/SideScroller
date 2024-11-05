using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos; 
    private float repeatWidth; // leveys jolla toistetaan tausta

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; // määritetään alkuperäinen taustan sijainti jotta tausta voidaan palauttaa siihen
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; // haetaan boxcolliderin koko ja määritetään sen leveys
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x -repeatWidth) { // jos taustan x on mennyt yli rajan tausta palautetaan alkuperäiseen sijaintiin
            transform.position = startPos; // palautetaan tausta alkuperäiseen sijaintiin
        }
    }
}
