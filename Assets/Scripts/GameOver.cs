using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    public string path;
	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            load(path);
        }

    }

    private void load(string myName){
        SceneManager.LoadScene(myName);
    }
    void Update () {
		
	}
}
