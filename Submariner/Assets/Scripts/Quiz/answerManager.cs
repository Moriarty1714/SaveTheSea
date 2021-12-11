using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answerManager : MonoBehaviour
{
    public bool isCorrect = false;
    public quizManager quiz;
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
        if (isCorrect)
        {
            Debug.Log("Correct!");
            quiz.isCorrect();
        }
        else 
        {
            Debug.Log("Wrong! noob...");
            quiz.isCorrect();
        }
    }

}
