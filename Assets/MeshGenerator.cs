using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;
    public Vector3[] vertices;
    int[] triangles;

    public int xSize = 20;
    public int zSize = 20;

    public float randX = 0.1f;
    public float randZ = 0.1f;

    
    void Start()
    {
        

       
            randX = Random.Range(.1f, .2f); //create a random values to make perlin noise more random
            randZ = Random.Range(.1f, .5f);
            

            mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;
            CreateShape();

        
    }
   void CreateShape() // this is main function to create shape for plain
    {
       
        vertices = new Vector3[(xSize + 1) * (zSize + 1)]; //vertices thats amount of zones which mesh made of 

        for(int z = 0, i = 0; z <= zSize; z++)
		{
            for (int x = 0; x <= xSize; x++)
            {
                //float y = Mathf.PerlinNoise(x * .3f, z * .3f) * 1.5f;
                float y = Mathf.PerlinNoise(x * randX, z * randZ) * 2f;
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }
        triangles = new int[xSize * zSize * 6]; // a triangles that fills the empty vertices
        int vert = 0;
        int tris = 0;
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++) //in the loop apllying all triangles sides to vertices 
            {

                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }
        

    }
    private void Update()
    {
        UpdateMesh();
    }
    void UpdateMesh() //function to update and recanculate mesh
    {
        if(mesh != null)
        {
            mesh.Clear();

            mesh.vertices = vertices;
            mesh.triangles = triangles;

            mesh.RecalculateNormals();
        }
        
        
    }
}
