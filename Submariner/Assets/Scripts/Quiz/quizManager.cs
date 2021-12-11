using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class quizManager : MonoBehaviour
{
    //Quiz
    public List<Questions> questions;
    public GameObject[] options;
    public int currQuestion;

    public TextMeshProUGUI questionTxt;
    // Start is called before the first frame update
    void Start()
    {
        GenerateQuestions();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void GenerateQuestions()
    {
        currQuestion = Random.Range(0, questions.Count-1);

        questionTxt.text = questions[currQuestion].Question;
        SetAnswers();
    }

    private void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<answerManager>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = questions[currQuestion].Answers[i];

            if (questions[currQuestion].CorrectAnswer == i)
            {
                options[i].GetComponent<answerManager>().isCorrect = true;
            }
        }
    }
    public void isCorrect()
    {
        questions.RemoveAt(currQuestion);
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Button>().interactable = false;
            if (options[i].GetComponent<answerManager>().isCorrect)
            {
                var newColorBlock = options[i].GetComponent<Button>().colors;
                newColorBlock.disabledColor = new Color (30f / 255f, 132f / 255f, 73f / 255f);
                options[i].GetComponent<Button>().colors = newColorBlock;
            }
        }
        StartCoroutine(generateNewQuestion(2));
    }

    IEnumerator generateNewQuestion(float timer) 
    {
        yield return new WaitForSeconds(timer);
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Button>().interactable = true;

            var newColorBlock = options[i].GetComponent<Button>().colors;
            newColorBlock.disabledColor = new Color(192f/255f, 57f / 255f, 43f / 255f);
            options[i].GetComponent<Button>().colors = newColorBlock;
        }
        GenerateQuestions();
    }

}
