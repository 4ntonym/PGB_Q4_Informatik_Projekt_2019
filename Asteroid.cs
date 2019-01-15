using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

    public float rotationSpeed;
    public float speed;
    public Transform player;
    
    void Start() {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * rotationSpeed;   // zufällige Rotation
        //GetComponent<Rigidbody>().velocity = Random.insideUnitSphere * speed; // Bewegung mit fester Geschwindigkeit in zufällige Richtung
        //GetComponent<Rigidbody>().velocity = Random.insideUnitSphere * Random.value * 10; // Bewegung mit zufälliger Geschwindigkeitsvektor in zufällige Richtung
    }

    void FixedUpdate() {
        GetComponent<Rigidbody>().velocity = (player.position - GetComponent<Rigidbody>().position) *(speed/5f); // Spieler verfolgen, Geschwindigkeit anpassbar
    }

    // differenzierte Kollisionsabfragen, da sonst Objekte sofort wegen einer Kollision mit der Begrenzung zerstört werden -> Tags bei Objekten setzen

    void OnTriggerEnter(Collider other) { // Kollisions mit anderen Objekten 
        if (other.tag == "Shot") { 
           // Instantiate(explosion, transform.position, transform.rotation); // Explosion erzeugen
           Destroy(other.gameObject);
           Destroy(gameObject);
        } 
        if (other.tag == "Player") {
           //Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
           //gameController.GameOver();
             Destroy(other.gameObject);
             Destroy(gameObject);
        }
        if (other.tag == "Enemy") {
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * -1f; // Abprallen des Asteroiden in Richtung, aus der er gekommen ist
        }

    void OnTriggerExit(Collider other) { // Verlassen des Spielraums
        if (other.tag == "Boundary"){ // -> Begrenzungsobjekt muss entsprechenden Tag bekommen
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity *-1f; // Abprallen des Asteroiden in Richtung, aus der er gekommen ist -> Level basieren auf Asteroidenanzahl
            //Destroy(gameObject); // Zerstören des Asteroiden -> Level sind zeitbasiert
        }
    }
}
