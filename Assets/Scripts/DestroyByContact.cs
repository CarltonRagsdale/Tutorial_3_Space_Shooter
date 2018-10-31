using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject Explosion;
    public GameObject playerExplosion;
    public int ScoreValue;
    private GameController gameController;

    void Start()
    {
        GameObject gamecontrollerObject = GameObject.FindWithTag("GameController");
        if (gamecontrollerObject != null)
        {
            gameController = gamecontrollerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' Script!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundry")
        {
            return;
        }
        Instantiate(Explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        gameController.AddScore(ScoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
