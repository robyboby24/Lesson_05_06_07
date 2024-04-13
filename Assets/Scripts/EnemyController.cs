using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = Vector2.MoveTowards(transform.position,
                                              Player.transform.position,
                                              2f* Time.deltaTime);  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
