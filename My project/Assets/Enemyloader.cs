using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyloader : MonoBehaviour
{

    public GameObject Enemy;
    
    private int i;
    
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        
        Instantiate(Enemy, transform.position, transform.rotation); // I would honestly use Quaternion.identity instead of spawn.transform.rotation, but it is up to you
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
