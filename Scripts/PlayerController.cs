using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    // Ce qui Change la vitesse du mouvement du "Player"
    public float speed;
    
    //Le code qui met a jour le compte des pickup
    public TextMeshProUGUI countText;
    
    //Le code qui met a jour les vies du "Player"
    public TextMeshProUGUI vieText;
    
    //initialise le text "you win!"
    public GameObject winTextObject;
    
    //initialise le text "you lose!"
    public GameObject loseTextObject;
    
    //initialisation du mouvement du "Player"
    private float movementX;
    private float movementY;
    
    //initialise un Rigidbody sur l'objet "Player"
    private Rigidbody rb;
    
    //initialise le code du pick up et de vie
    private int count;
    private int nbrvie;

    //Ce qui met a jour a partir du premier Frame en temps reel.
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        //initialise le nombre de Pickup quon commence dans le compteur
        count = 0;
        SetCountText();
        // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winTextObject.SetActive(false);
        
        //initialise le nombre de vie quon commence dans le compteur
        nbrvie = 2;
        SetVieText();
        loseTextObject.SetActive(false);





    }

    void FixedUpdate()
    {
        
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    //Les Reactions entre objet et tag en collision
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            // Add one to the score variable 'count'
            count = count + 1;

            // Run the 'SetCountText()' function (see below)
            SetCountText();
            
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            
            nbrvie = nbrvie - 1;

            SetVieText();
        }
    }

    // Le controle avec le keyboard
    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        movementY = v.y;
    }

    //Condition pour gagner
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 12)
        {
            // Set the text value of your 'winText'
            winTextObject.SetActive(true);
        }
    }
    void SetVieText()
    {
        vieText.text = "Vie: " + nbrvie.ToString();

        if (nbrvie <= 0)
        {
            loseTextObject.SetActive(true);
        }
    }

    

    
}