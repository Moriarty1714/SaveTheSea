using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        lastSpawnTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastSpawnTime + timeSpawn < Time.time) 
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
            timeSpawn -= 0.01f;
        }
    }
}
