using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float lastSpawnTime;
    public float timeSpawn;
    public Vector2 objScale;
    public GameObject trash;
    public GameObject nature;
    public List<Sprite> natureImg;
    public List<Sprite> trashImg;
    public buzoMov buzo;

    public GameObject quiz;
    bool quizDone;

    void Start()
    {
        lastSpawnTime = 0;
        quizDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastSpawnTime + timeSpawn < Time.time && !quiz.activeSelf) 
        {
            if (Random.Range(-1f, 1f) < 0) 
            {
                int imgID = Random.Range(0, trashImg.Count - 1);
                GameObject tmpTrash = GameObject.Instantiate(trash, new Vector3(10f, Random.Range(2.5f, -3f), 0), Quaternion.identity);
                tmpTrash.GetComponent<SpriteRenderer>().sprite = trashImg[imgID];
            }
            else 
            {
                int imgID = Random.Range(0, natureImg.Count - 1);
                GameObject tmpNature = GameObject.Instantiate(nature, new Vector3(10f, Random.Range(2.5f, -3f), 0), Quaternion.identity);
                tmpNature.GetComponent<SpriteRenderer>().sprite = natureImg[imgID];
            }      
            
            lastSpawnTime = Time.time;
        }

        if (buzo.getScore() >= 10 && !quizDone) 
        {
            StartCoroutine(aciveQuiz(1f));
            buzo.movActive = false;
            quizDone = true;
        }
    }

    public IEnumerator aciveQuiz(float timer) 
    {
        yield return new WaitForSeconds(timer);
        quiz.gameObject.SetActive(true);
        buzo.movActive = true;
    }
}
