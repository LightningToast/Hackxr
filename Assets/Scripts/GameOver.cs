using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public string newScene;
    public GameObject prefab;
    public GameObject head;
    private bool isDone = false;

    private Transform self;
    // Use this for initialization
    void Start()
    {
        self = transform;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!isDone)
        {
            GameObject temp = Instantiate(prefab, head.transform.position + 3 * head.transform.forward, head.transform.rotation);
            temp.GetComponent<TextMesh>().text = "Game Over";
            isDone = true;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
