using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] bigPrefabs;
    public GameObject[] battleground;
    public GameObject[] humans;
    public GameObject[] aliens;

    public Vector3 mainZoneSize;
    public Vector3 mainZonePoss;
    public Vector3[] mediumSize;
    public Vector3[] mediumPoss;
    public Vector4[] smallSize;
    public Vector4[] smallPoss;
    public GameObject[] obj;
    public Vector3 worldCenter;
    int field;
    int newField;
    int sideFild1;
    int sideFild2;
    int rnd;
    Vector3 pos;
    Vector3 newPos;
    public float obstacleCheckRadius = 10f;
    // Start is called before the first frame update  
    private void Start() // Start runs all the stages one by one
    {
        field = Random.Range(1, 5); //Make a random choise between 4 fields to set up first base 
        Step1();
        Step2();
        Step3();
        Step4();

    }
   

    void Step1()
    {
        int rnd = Random.Range(3, 6);
        for (int i = 0; i < rnd; i++) //takes and creates a zone which able to spawn object 
        {
            Vector3 pos = mainZonePoss + new Vector3(Random.Range(-mainZoneSize.x / 2f, mainZoneSize.x / 2f), Random.Range(-mainZoneSize.y / 2f, mainZoneSize.y / 2f), Random.Range(-mainZoneSize.z / 2f, mainZoneSize.z / 2f));
            int rnd2 = Random.Range(0, 3);
            obj[i] = Instantiate(bigPrefabs[rnd2], pos, Quaternion.identity);// deploys big prefabs
        }
        
           int bigRand = Random.Range(1, 4);
           if(bigRand == 1)// whith some chance it might add a specifi prefab that should be unic
            {
                Instantiate(bigPrefabs[3], pos, Quaternion.Euler(0, 0, 90));
            }else if (bigRand == 2)
            {
                Instantiate(bigPrefabs[5], pos, Quaternion.identity);
            }
            else
            {
                Instantiate(bigPrefabs[6], pos, Quaternion.identity);
            }
    }
    void Step2() // step 2 creates enemy base 
    {
        
        int rand = Random.Range(10, 20); //random amount of spawns

        for (int i = 0; i < rand; i++)
        {
            pos = mediumPoss[field - 1] + new Vector3(Random.Range(-mediumPoss[field - 1].x / 2f, mediumPoss[field - 1].x / 2f), Random.Range(-mediumPoss[field - 1].y / 2f, mediumPoss[field - 1].y / 2f), Random.Range(-mediumPoss[field - 1].z / 2f, mediumPoss[field - 1].z / 2f));
            int rnd2 = Random.Range(1, 17); //which objects 
            Instantiate(aliens[rnd2], pos, Quaternion.LookRotation(worldCenter));
           
            Collider[] colliders = Physics.OverlapSphere(pos, obstacleCheckRadius);// we need to use coliders to avoid overlapping 
            foreach (Collider col in colliders)
            {
                // If this collider is tagged "Obstacle"
                if (col.tag == "Obstacle")
                {
                    aliens[rnd2].transform.position = new Vector3(Random.Range(-mediumPoss[field - 1].x / 2f, mediumPoss[field - 1].x / 2f), Random.Range(-mediumPoss[field - 1].y / 2f, mediumPoss[field - 1].y / 2f), Random.Range(-mediumPoss[field - 1].z / 2f, mediumPoss[field - 1].z / 2f));

                }
            }
        }
        Instantiate(aliens[0], pos, Quaternion.LookRotation(worldCenter));
        if (rand <= 12)
        {
            Instantiate(aliens[17], pos, Quaternion.LookRotation(worldCenter));
        }
    }
    void Step3() // creates a enemy base in oposite side of first base 
    {
        if(field == 1)
        {
            newField = 4;
            sideFild1 = 3;
            sideFild2 = 2;
            

        }
        else if (field == 4)
        {
            newField = 1;
            sideFild1 = 3;
            sideFild2 = 2;
        }
        else if (field == 2)
        {
            newField = 3;
            sideFild1 = 1;
            sideFild2 = 4;

        }
        else if (field == 3)
        {
            newField = 2;
            sideFild1 = 1;
            sideFild2 = 4;
        }
        int rand = Random.Range(10, 20); //random amount of spawns

        for (int i = 0; i < rand; i++)
        {
            newPos = mediumPoss[newField - 1] + new Vector3(Random.Range(-mediumPoss[newField - 1].x / 2f, mediumPoss[newField - 1].x / 2f), Random.Range(-mediumPoss[newField - 1].y / 2f, mediumPoss[newField - 1].y / 2f), Random.Range(-mediumPoss[newField - 1].z / 2f, mediumPoss[newField - 1].z / 2f));
            int rnd2 = Random.Range(1, 14); //which objects 
            Instantiate(humans[rnd2], newPos, Quaternion.LookRotation(worldCenter));
            Collider[] colliders = Physics.OverlapSphere(newPos, obstacleCheckRadius);
            foreach (Collider col in colliders)
            {
                // If this collider is tagged "Obstacle"
                if (col.tag == "Obstacle")
                {
                    humans[rnd2].transform.position = new Vector3(Random.Range(-mediumPoss[newField - 1].x / 2f, mediumPoss[newField - 1].x / 2f), Random.Range(-mediumPoss[newField - 1].y / 2f, mediumPoss[newField - 1].y / 2f), Random.Range(-mediumPoss[newField - 1].z / 2f, mediumPoss[newField - 1].z / 2f));

                }
            }
        }
        Instantiate(humans[0], newPos, Quaternion.LookRotation(worldCenter));

    }
    void Step4()
    {
        int rand = Random.Range(10, 20); //random amount of spawns

        for (int i = 0; i < rand; i++)
        {
            pos = mediumPoss[sideFild1 - 1] + new Vector3(Random.Range(-mediumPoss[sideFild1 - 1].x / 2f, mediumPoss[sideFild1 - 1].x / 2f), Random.Range(-mediumPoss[sideFild1 - 1].y / 2f, mediumPoss[sideFild1 - 1].y / 2f), Random.Range(-mediumPoss[sideFild1 - 1].z / 2f, mediumPoss[sideFild1 - 1].z / 2f));
            int rnd2 = Random.Range(0, 22); //which objects 
            Instantiate(battleground[rnd2], pos, Quaternion.LookRotation(worldCenter));

            Collider[] colliders = Physics.OverlapSphere(pos, obstacleCheckRadius);
            foreach (Collider col in colliders)
            {
                // If this collider is tagged "Obstacle"
                if (col.tag == "Obstacle")
                {
                    battleground[rnd2].transform.position = new Vector3(Random.Range(-mediumPoss[sideFild1 - 1].x / 2f, mediumPoss[sideFild1 - 1].x / 2f), Random.Range(-mediumPoss[sideFild1 - 1].y / 2f, mediumPoss[sideFild1 - 1].y / 2f), Random.Range(-mediumPoss[sideFild1 - 1].z / 2f, mediumPoss[sideFild1 - 1].z / 2f));

                }
            }
        }


        int randA = Random.Range(10, 20); //random amount of spawns

        for (int i = 0; i < randA; i++)
        {
            pos = mediumPoss[sideFild2 - 1] + new Vector3(Random.Range(-mediumPoss[sideFild2 - 1].x / 2f, mediumPoss[sideFild2 - 1].x / 2f), Random.Range(-mediumPoss[sideFild2 - 1].y / 2f, mediumPoss[sideFild2 - 1].y / 2f), Random.Range(-mediumPoss[sideFild2 - 1].z / 2f, mediumPoss[sideFild2 - 1].z / 2f));
            int rnd2 = Random.Range(0, 22); //which objects 
            Instantiate(battleground[rnd2], pos, Quaternion.LookRotation(worldCenter));

            Collider[] colliders = Physics.OverlapSphere(pos, obstacleCheckRadius);
            foreach (Collider col in colliders)
            {
                // If this collider is tagged "Obstacle"
                if (col.tag == "Obstacle")
                {
                    battleground[rnd2].transform.position = new Vector3(Random.Range(-mediumPoss[sideFild2 - 1].x / 2f, mediumPoss[sideFild2 - 1].x / 2f), Random.Range(-mediumPoss[sideFild2 - 1].y / 2f, mediumPoss[sideFild2 - 1].y / 2f), Random.Range(-mediumPoss[sideFild2 - 1].z / 2f, mediumPoss[sideFild2 - 1].z / 2f));

                }
            }
        }
    }
    private void OnDrawGizmos()     // createse 4 different zones by deviding main zone on 4 simillar parts
        {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(mainZonePoss, mainZoneSize);
        if (mediumSize != null)
        {

            for (int x = 0; x < mediumSize.Length; x++)
            {
                if (x == 0)
                {
                    Gizmos.color = new Color(255, 1, 1, 1f);
                    mediumSize[x] = new Vector3(mainZoneSize.x / 2.05f, 0.7f, mainZoneSize.z / 2.05f);
                    mediumPoss[x] = new Vector3(mainZonePoss.x / 2, 0.7f, mainZonePoss.z / 2);
                    Gizmos.DrawCube(mediumPoss[x], mediumSize[x]);
                    
                }
                else if (x == 1)
                {
                    Gizmos.color = new Color(255, 1, 1, 0.5f);
                    mediumSize[x] = new Vector3(mainZoneSize.x / 2.05f, 0.7f, mainZoneSize.z / 2.05f);
                    mediumPoss[x] = new Vector3(mediumPoss[0].x + mediumSize[0].x + 5, 0.7f, mediumPoss[0].z);
                    Gizmos.DrawCube(mediumPoss[x], mediumSize[x]);
                }
                else if (x == 2)
                {
                    Gizmos.color = new Color(1, 255, 1, 0.5f);
                    mediumSize[x] = new Vector3(mainZoneSize.x / 2.05f, 0.7f, mainZoneSize.z / 2.05f);
                    mediumPoss[x] = new Vector3(mediumPoss[0].x, 0.7f, mediumPoss[0].z + mediumSize[0].z + 5);
                    Gizmos.DrawCube(mediumPoss[x], mediumSize[x]);
                }
                else if (x == 3)
                {
                    Gizmos.color = new Color(1, 1, 255, 0.5f);
                    mediumSize[x] = new Vector3(mainZoneSize.x / 2.05f, 0.7f, mainZoneSize.z / 2.05f);
                    mediumPoss[x] = new Vector3(mediumPoss[0].x + mediumSize[0].x + 5, 0.7f, mediumPoss[0].z + mediumSize[0].z + 5);
                    Gizmos.DrawCube(mediumPoss[x], mediumSize[x]);
                }
            }
        }
    }
}
