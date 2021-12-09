using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class buzoMov : MonoBehaviour
{
    [SerializeField] private float velocity = 0;
    public TextMeshProUGUI scoreTxt;
    [SerializeField] private int score = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreTxt.text = "SCORE: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 2.5f)
        {

                transform.position = new Vector3(transform.position.x, transform.position.y + velocity, transform.position.z);


            //if (transform.rotation.z <= 0.2f)
            //{
            //    transform.Rotate(new Vector3(0, 0, 1), 0.1f);
            //}
        }

        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > -3f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - velocity, transform.position.z);
            //if (transform.rotation.z >= -0.2f)
            //{
            //    transform.Rotate(new Vector3(0, 0, -1), 0.1f);
            //}
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
