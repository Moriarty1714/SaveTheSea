using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answerManager : MonoBehaviour
{
    public bool isCorrect = false;
    public GameObject quiz;
    public buzoMov buzo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Answer() 
    {
        quiz.GetComponent<quizManager>().isCorrect();
        if (isCorrect)
        {
            Debug.Log("Correct!");
            buzo.setScore(10);
        }
        else 
        {
            Debug.Log("Wrong! noob...");
            buzo.setScore(-5);
        }
    }

    IEnumerator endQuiz(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }

}
