using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{

    public GameObject parent; /// Parent GameObject.
    public GameObject Enemy; /// Enemy prefab.
    public GameObject Explosive;
    public GameObject EnemySpawn1; /// Spawn point for enemy clone 1.
    public GameObject EnemySpawn2; /// Spawn point for enemy clone 2.
    public GameObject EnemySpawn3; /// Spawn point for enemy clone 3.
    public GameObject EnemySpawn4; /// Spawn point for enemy clone 4.
    public GameObject EnemySpawn5; /// Spawn point for enemy clone 5.
    public GameObject EnemySpawn6; /// Spawn point for enemy clone 6.
    public GameObject EnemySpawn7; /// Spawn point for enemy clone 7.
    public GameObject EnemySpawn8; /// Spawn point for enemy clone 8.
    public GameObject EnemySpawn9; /// Spawn point for enemy clone 9.
    public GameObject EnemySpawn10; /// Spawn point for enemy clone 10.
    public GameObject EnemySpawn11; /// Spawn point for enemy clone 11.
    public GameObject EnemySpawn12; /// Spawn point for enemy clone 12.
    public GameObject EnemySpawn13; /// Spawn point for enemy clone 13.
    public GameObject EnemySpawn14; /// Spawn point for enemy clone 14.

    public GameObject ExplosiveSpawn1; /// Spawn point for enemy clone 1.
    public GameObject ExplosiveSpawn2; /// Spawn point for enemy clone 2.
    public GameObject ExplosiveSpawn3; /// Spawn point for enemy clone 3.
    public GameObject ExplosiveSpawn4; /// Spawn point for enemy clone 4.
    private GameObject Enemy1; /// Enemy clone 1.
    private GameObject Enemy2; /// Enemy clone 2.
    private GameObject Enemy3; /// Enemy clone 3.
    private GameObject Enemy4; /// Enemy clone 4.
    private GameObject Enemy5; /// Enemy clone 5.
    private GameObject Enemy6; /// Enemy clone 6.
    private GameObject Enemy7; /// Enemy clone 7.
    private GameObject Enemy8; /// Enemy clone 8.
    private GameObject Enemy9; /// Enemy clone 9.
    private GameObject Enemy10; /// Enemy clone 10.
    private GameObject Enemy11; /// Enemy clone 11.
    private GameObject Enemy12; /// Enemy clone 12.
    private GameObject Enemy13; /// Enemy clone 13.
    private GameObject Enemy14; /// Enemy clone 14.

    private GameObject Explosive1;
    private GameObject Explosive2;
    private GameObject Explosive3;
    private GameObject Explosive4;

    public GameObject Target; /// GameObject Target.
    // Start is called before the first frame update
    void Start()
    {
        Spawner();
    }

    void Spawner()
    {
        Enemy1 = Instantiate(Enemy, EnemySpawn1.transform.position, EnemySpawn1.transform.rotation);
        Enemy2 = Instantiate(Enemy, EnemySpawn2.transform.position, EnemySpawn2.transform.rotation);
        Enemy3 = Instantiate(Enemy, EnemySpawn3.transform.position, EnemySpawn3.transform.rotation);
        Enemy4 = Instantiate(Enemy, EnemySpawn4.transform.position, EnemySpawn4.transform.rotation);
        Enemy5 = Instantiate(Enemy, EnemySpawn5.transform.position, EnemySpawn5.transform.rotation);
        Enemy6 = Instantiate(Enemy, EnemySpawn6.transform.position, EnemySpawn6.transform.rotation);
        Enemy7 = Instantiate(Enemy, EnemySpawn7.transform.position, EnemySpawn7.transform.rotation);
        Enemy8 = Instantiate(Enemy, EnemySpawn8.transform.position, EnemySpawn8.transform.rotation);
        Enemy9 = Instantiate(Enemy, EnemySpawn9.transform.position, EnemySpawn9.transform.rotation);
        Enemy10 = Instantiate(Enemy, EnemySpawn10.transform.position, EnemySpawn10.transform.rotation);
        Enemy11 = Instantiate(Enemy, EnemySpawn11.transform.position, EnemySpawn11.transform.rotation);
        Enemy12 = Instantiate(Enemy, EnemySpawn12.transform.position, EnemySpawn12.transform.rotation);
        Enemy13 = Instantiate(Enemy, EnemySpawn13.transform.position, EnemySpawn13.transform.rotation);
        Enemy14 = Instantiate(Enemy, EnemySpawn14.transform.position, EnemySpawn14.transform.rotation);

        Explosive1 = Instantiate(Explosive, ExplosiveSpawn1.transform.position, ExplosiveSpawn1.transform.rotation);
        Explosive2 = Instantiate(Explosive, ExplosiveSpawn2.transform.position, ExplosiveSpawn2.transform.rotation);
        Explosive3 = Instantiate(Explosive, ExplosiveSpawn3.transform.position, ExplosiveSpawn3.transform.rotation);
        Explosive4 = Instantiate(Explosive, ExplosiveSpawn4.transform.position, ExplosiveSpawn4.transform.rotation);

    }
}
