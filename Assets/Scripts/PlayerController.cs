using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb; // rigidbody hallitsee fysiikkaa
    private Animator playerAnim; // pelaajan animaatioiden hallinta
    private AudioSource playerAudio; // audion hallinta
    public float jumpForce; // hypyn voima
    public float gravityModifier; // painovoiman kerroin
    public bool isOnGround = true; // kertoo onko pelaaja maassa
    public bool gameOver = false; // pelin tila
    public ParticleSystem explosionParticle; // törmäys partikkeli
    public ParticleSystem dirtParticle; // dirt partikkeli
    public AudioClip jumpSound; // äänet hypylle
    public AudioClip crashSound; // äänet törmäykselle
    public GameManagerScript gameManager; // viittaus gamemanagerscriptii 

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); 
        playerAnim = GetComponent<Animator>(); // haetaan komponentit pelaajalta
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>(); // haetaan audiokomponentti pelaajalta
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) // tarkistetaan painaako pelaaja spacea, onko hän maassa ja onko peli käynnissä
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // 
            isOnGround = false; // pelaaja ei ole enään maassa hypyn jälkeen
            playerAnim.SetTrigger("Jump_trig"); // asetetaan hyppyanimaatio
            dirtParticle.Stop(); // pysäytetään dirt partikkelit kun pelaaja hyppää
            playerAudio.PlayOneShot(jumpSound, 1.0f); // toistetaan hypyn ääni
        }
    }

    private void OnCollisionEnter(Collision collision) // käsitellään törmäyksiä muiden peliobjektien kanssa
    {

        if(collision.gameObject.CompareTag("Ground")) // kun peliobjekti osuu maahan kutsutaan tätä
        {
            isOnGround = true; // pelaaja on maassa
            dirtParticle.Play(); // toistetaan dirt partikkeli
        } 
        else if(collision.gameObject.CompareTag("Obstacle")) // kun törmäys tapahtuu peliobjekti "Obstaclen" kanssa kutsutaan näitä
        {
            Debug.Log("Game Over");
            gameOver = true; // pelin tila on "game over"
            playerAnim.SetBool("Death_b", true); 
            playerAnim.SetInteger("DeathType_int", 1); 
            explosionParticle.Play(); // törmäyksen animaatiot ja partikkelit
            dirtParticle.Stop(); 
            playerAudio.PlayOneShot(crashSound, 1.0f); // dirt partikkeli lopetetaan ja törmäys ääni toistetaan
            gameManager.playerDead(); // ilmoitetaan gamemanagerille että pelaaja on törmännyt
        }
    }
}
