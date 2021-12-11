using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class buzoMov : MonoBehaviour
{
    [SerializeField] private float velocity = 0;
    public TextMeshProUGUI scoreTxt;
    [SerializeField] private int score = 0;

    private float idlePosY;
    private float timeElapsed = 0;
    public float idleLerpDuration;
    private bool isIdleUp = true;

    // Start is called before the first frame update
    void Start()
    {
        scoreTxt.text = "SCORE: " + score.ToString();
        idlePosY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 2.5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + velocity, transform.position.z);
            if (transform.rotation.z <= 0.2f)
            {
                transform.Rotate(new Vector3(0, 0, 1), 0.2f);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > -3f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - velocity, transform.position.z);
            if (transform.rotation.z >= -0.2f)
            {
                transform.Rotate(new Vector3(0, 0, -1), 0.2f);
            }
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            idlePosY = transform.position.y;
            timeElapsed = 0;
        }
        else
        {
            if (transform.rotation.z > 0)
            {
                transform.Rotate(new Vector3(0, 0, -1), 0.2f);
            }
            else if (transform.rotation.z < 0)
            {
                transform.Rotate(new Vector3(0, 0, 1), 0.2f);
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

                if (transform.position.y <= idlePosY+0.01f)
                {
                    isIdleUp = true;
                    timeElapsed = 0;
                }
            }
            Debug.Log("PosY: "+ transform.position.y +", IdlePosY: " + idlePosY + ", IsUp?: " + isIdleUp);

        }

 
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Trash(Clone)")
        {
            score++;
            scoreTxt.text = "SCORE: " + score.ToString();
        }
        else
        {
            if (score > 0){
                score-=3;
                if (score < 0)
                {
                    scoreTxt.text = "SCORE: 0";
                }
                else
                    scoreTxt.text = "SCORE: " + score.ToString();
            }
        }
            

    }
}
