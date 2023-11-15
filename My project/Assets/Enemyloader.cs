using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyloader : MonoBehaviour
{

    public GameObject Enemy;
    
    private int i;
    private Vector3 Spawn;
    public GameObject player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        Spawn.x = Random.Range(-18f, 14f);
        while(Spawn.x < player.transform.position.x+3f && Spawn.x > player.transform.position.x - 3f)
        {
            Spawn.x = Random.Range(-18f, 14f);
        }
        Spawn.y = Random.Range(-21f, -1f);
        while (Spawn.y < player.transform.position.y + 3f && Spawn.y > player.transform.position.y - 3f)
        {
            Spawn.y = Random.Range(-21f, -1f);
        }
        Spawn.z = transform.position.z;
        Instantiate(Enemy,  Spawn, transform.rotation); // I would honestly use Quaternion.identity instead of spawn.transform.rotation, but it is up to you
        i++;
        yield return new WaitForSeconds(1.5f); // or you can put any amount of seconds in here
        if (i < 10) StartCoroutine(SpawnEnemies());
        // don't need an else because it won't do anything when the condition is not met
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
