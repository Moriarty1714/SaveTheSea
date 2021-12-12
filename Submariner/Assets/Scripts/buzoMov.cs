using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class buzoMov : MonoBehaviour
{
    Rigidbody2D body;
    [SerializeField] private float velocity = 0;
    public TextMeshProUGUI scoreTxt;
    [SerializeField] private int score = 0;

    private float idlePosY;
    private float timeElapsed = 0;
    public float idleLerpDuration;
    private bool isIdleUp = true;

    public GameObject quiz;
    public bool movActive = true;

    // Start is called before the first frame update
    void Start()
    {
        scoreTxt.text = "SCORE: " + score.ToString();
        idlePosY = transform.position.y;

        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 3f && movActive && !quiz.activeSelf)
        {
            if (transform.rotation.z < 0)
            {
                body.velocity = new Vector2(0, (velocity) / 1.25f * Time.deltaTime);
                transform.Rotate(new Vector3(0, 0, 1), 100f * Time.deltaTime);

            }
            else
            {
                body.velocity = new Vector2(0, velocity * Time.deltaTime);
                if (transform.rotation.z <= 0.3f)
                {
                    transform.Rotate(new Vector3(0, 0, 1), 60f * Time.deltaTime);
                }
            }

            idlePosY = transform.position.y;
            timeElapsed = 0;
            isIdleUp = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > -3f && movActive && !quiz.activeSelf)
        {
            if (transform.rotation.z > 0)
            {
                body.velocity = new Vector2(0, (-velocity) / 1.5f * Time.deltaTime);
                transform.Rotate(new Vector3(0, 0, -1), 100f * Time.deltaTime);
            }
            else
            {
                body.velocity = new Vector2(0, -velocity * Time.deltaTime);
                if (transform.rotation.z >= -0.3f)
                {
                    transform.Rotate(new Vector3(0, 0, -1), 60f * Time.deltaTime);
                }

            }

            idlePosY = transform.position.y;
            timeElapsed = 0;
            isIdleUp = true;
        }
        else
        {
            body.velocity = new Vector2(0, 0);
            if (transform.rotation.z > 0.05f)
            {
                transform.Rotate(new Vector3(0, 0, -1), 80f * Time.deltaTime);
            }
            else if (transform.rotation.z < -0.05f)
            {
                transform.Rotate(new Vector3(0, 0, 1), 80f * Time.deltaTime);
            }

            if (isIdleUp)
            {
                transform.position = new Vector3(transform.position.x, Mathf.SmoothStep(idlePosY, idlePosY + 0.3f, timeElapsed / idleLerpDuration), transform.position.z);
                timeElapsed += Time.deltaTime;


                if (transform.position.y >= idlePosY + 0.29f)
                {
                    isIdleUp = false;
                    timeElapsed = 0;
                }

            }
            else
            {
                transform.position = new Vector3(transform.position.x, Mathf.SmoothStep(idlePosY + 0.3f, idlePosY, timeElapsed / idleLerpDuration), transform.position.z);
                timeElapsed += Time.deltaTime;

                if (transform.position.y <= idlePosY + 0.01f)
                {
                    isIdleUp = true;
                    timeElapsed = 0;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!quiz.activeSelf)
        {
            if (collision.gameObject.name == "Trash(Clone)")
            {
                setScore(+1);
            }
            else
            {
                if (score > 0)
                {
                    setScore(-3);
                }
            }
        }

    }
    public int getScore () {
        return score;
    }
    public void setScore(int s)
    {
        score += s;
        if (score < 0)
        {
            scoreTxt.text = "PUNTS: 0";
        }
        else
            scoreTxt.text = "PUNTS: " + score.ToString();
    }
}
