// Unterklasse der Klasse Asteroid
// für Asteroiden, die auf den Spieler schießen
// bewegen sich ansonsten mit konstanter Geschwindigkeit

using UnityEngine;

public class AsteroidShooter : Asteroid {

    public int frequency;

    new void Start()
    {
        base.Start();
        rb.velocity = Random.insideUnitSphere * speed * Time.deltaTime; // Bewegung mit fester Geschwindigkeit in zufällige Richtung
    }

    void Update()
    {
       // Schuss nach bestimmter Zeit abfeuern 
    }
}
