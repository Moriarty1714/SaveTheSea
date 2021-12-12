using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stuffMovement : MonoBehaviour
{
    public float velocity;
    private float rotation;
    // Start is called before the first frame update
    void Start()
    {
        rotation = Random.Range(-0.3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x-(velocity*Time.deltaTime), transform.position.y, transform.position.z);
        transform.Rotate(new Vector3(0, 0, 1), rotation);

        if (transform.position.x < -10) 
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(deleteWithDelay(0.1f));
    }


    private IEnumerator deleteWithDelay(float timer)
    {
        yield return new WaitForSeconds(timer);
        GameObject.Destroy(this.gameObject); 

    }
}
