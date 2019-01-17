using UnityEngine;

//Unterklasse für Asteroiden, die den Spieler verfolgen
public class MagnetAsteroid : Asteroid{


    public Transform player;

    void FixedUpdate() {
        rb.velocity = (player.position - rb.position) * speed * Time.deltaTime; // Spieler verfolgen, Geschwindigkeit anpassbar
    }

    void OnTriggerEnter(Collider other) { // Kollisions mit anderen Objekten 

        // differenzierte Kollisionsabfragen, da sonst Objekte sofort wegen einer Kollision mit der Begrenzung zerstört werden -> Tags bei Objekten setzen
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

    }
}
	
