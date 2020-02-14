using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacement : MonoBehaviour
{
    /*public Canvas win;*/
    public GameObject obstacle;
    public GameObject respawn;
    public GameObject perso;
    public GameObject mur;
    public Renderer player;
    public Vector3 impulse = new Vector3(0.0f, 15.0f, 0.0f);
    public Rigidbody rb;
    public bool auSol;
    public bool mure = false;
    [SerializeField]
    private float rayDistance;
    [SerializeField]
    private float avance;
    [SerializeField]
    public LayerMask layers;
    public Renderer rend;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }
    private void Awake()
    {
        obstacle = GameObject.FindWithTag("obstacle");
        respawn = GameObject.FindWithTag("respawn");
        perso = GameObject.FindWithTag("perso");
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "obstacle")
        {
            perso.transform.localPosition = respawn.transform.localPosition;
        }
        if (collision.collider.tag == "fin")
        {
            rend.enabled = false;
            Time.timeScale = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * rayDistance, Color.blue);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, rayDistance, layers))
        {
            auSol = true;
        }
        else
        {
            auSol = false;
        }

        if (mure == false) //avancer
        {
            transform.Translate(-6.5f * Time.deltaTime, 0, 0);
        }

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * avance, Color.blue);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, avance, layers))
        {
            transform.Translate(6.5f * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && auSol == true) //Sauter
        {
            rb.AddForce(impulse, ForceMode.Impulse);
        }

        if (Input.GetKeyDown("r"))
        {
            rend.enabled = true;
            perso.transform.localPosition = respawn.transform.localPosition;
        }
    }
}
