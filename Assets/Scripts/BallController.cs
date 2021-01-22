using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public Text countText;
    private int count;
    public float speed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        speed = 7;
        countText.text = "Count: " + count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x,0,z);

        rb.AddForce(movement * speed);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            countText.text = "Count: " + count.ToString();
        }

        if (other.gameObject.CompareTag("Spikes"))
        {
            resetScene();
        }
    }


    private void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetSceneByName("SampleScene").buildIndex);
    }
}
