using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class changerDeScene : MonoBehaviour
{
    public bool fin=false;
    public GameObject perso;
    // Start is called before the first frame update
    private void Awake()
    {
        perso = GameObject.FindWithTag("perso");
    }
    void Start()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "perso")
        {
            fin = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fin == true)
        {
            SceneManager.LoadScene("sceneDeFin");
        }
    }
}
