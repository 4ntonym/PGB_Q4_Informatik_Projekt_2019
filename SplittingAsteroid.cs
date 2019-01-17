using UnityEngine;
using System.Collections;


public class SplittingAsteroid : Asteroid {

    public int size; //Angabe zur Größe des Asteroiden (1-> Klein, 2-> Mittel, 3-> Groß
    public GameObject asteroid;

    

    new void Start()
    {
        base.Start();
        rb.velocity = Random.insideUnitSphere * speed * Time.deltaTime;
        
    }

    void OnTriggerEnter(Collider other) { // Kollisions mit anderen Objekten 

        // differenzierte Kollisionsabfragen, da sonst Objekte sofort wegen einer Kollision mit der Begrenzung zerstört werden -> Tags bei Objekten setzen
        if (other.tag == "Shot") {
            // Instantiate(explosion, transform.position, transform.rotation); // Explosion erzeugen
            if (size == 3)
            {
                //SplittingAsteroid sA = gameObject.AddComponent<SplittingAsteroid>() as SplittingAsteroid;
                Instantiate(asteroid, transform.position, transform.rotation);
                Instantiate(asteroid, transform.position, transform.rotation);
                Destroy(gameObject);

            }
            if (size == 2)
            {
                Instantiate(asteroid, transform.position + new Vector3(5f, 5f, 5f), transform.rotation);
                Instantiate(asteroid, transform.position + new Vector3(-5f, -5f, -5f), transform.rotation);
                Destroy(gameObject);
            }
            if (size == 1)
            {
                Destroy(gameObject);
            }

        }

        if (other.tag == "Player") {
            // Instantiate(explosion, transform.position, transform.rotation); // Explosion erzeugen
            //Spieler bekommt entsprechend Leben abgezogen (Eventuelle Zerstörung des Raumschiffs in Raumschiffklasse
            



        }

        if (other.tag == "Enemy") {
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * -1f; // Abprallen des Asteroiden in Richtung, aus der er gekommen ist
        }
    }
}
