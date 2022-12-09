using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallControl : MonoBehaviour
{
    public int score;
    public Text ScoreText;
    public Text ScoreText2;
    public Text Warning;
    [SerializeField]private Rigidbody rb;
    public float speed = 5f;
    public float jumpSpeed = 12f;
    private bool onFloor=true;
    private bool onFinish=false;
    private GameObject finishScreen;
    // Start is called before the first frame update
    void Start()
    {
        finishScreen = GameObject.Find("FinishScreen");
        finishScreen.SetActive(false);
    }

    private void Update()
    {
        ScoreText2.text = "SCORE: " + score;
        if (Input.GetKeyDown(KeyCode.Space) && onFloor==true)
        {
            rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
            onFloor= false;
        }
        if (score == 120)
        {
            onFinish = true;
            Time.timeScale = 0;
            finishScreen.SetActive(true);
        }
        if (transform.position.y < -10)
        {
            Warning.text = "               Failed";
            finishScreen.SetActive(true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (onFinish==false)
        {
            float hori = Input.GetAxis("Horizontal");
            float verti = Input.GetAxis("Vertical");
            Vector3 force = new Vector3(hori, 0, verti);
            rb.AddForce(force * speed*Time.deltaTime*10f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CubeTag"))
        {
            Destroy(other.gameObject);
            score += 10;
            ScoreText.text = "Score: " + score;
        }

        if (other.CompareTag("ButtonTag"))
        {
            other.transform.position -= new Vector3(0,0.18f,0);
            Destroy(GameObject.FindWithTag("WallTag"));
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ButtonTag"))
        {
            other.transform.position += new Vector3(0, 0.18f, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="onFloor")
        {
            onFloor = true;
            Debug.Log("içerde");
        }

    }
}
