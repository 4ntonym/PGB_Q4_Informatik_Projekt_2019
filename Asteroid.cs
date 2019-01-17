using UnityEngine;
using System.Collections;

//Oberklasse für weitere Asteroiden-Typen

public class Asteroid : MonoBehaviour { 

    public float rotationSpeed;
    public float speed;
    public Rigidbody rb;
    new public Transform transform;


    public void Start() {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * rotationSpeed * Time.deltaTime; //Geschwindigkeit für Zeitänderung statt Framerate
    }

    void OnTriggerEnter(Collider other) { // Kollisions mit anderen Objekten 
        
    }

    void OnTriggerExit(Collider other) { // Verlassen des Spielraums
        if (other.tag == "Boundary"){ // -> Begrenzungsobjekt muss entsprechenden Tag bekommen
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity *-1f; // Abprallen des Asteroiden in Richtung, aus der er gekommen ist -> Level basieren auf Asteroidenanzahl
            //Destroy(gameObject); // Zerstören des Asteroiden -> Level sind zeitbasiert
        }
    }
}
