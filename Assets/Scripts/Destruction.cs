using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{

    public GameObject mesh;
    public int numOfCubes = 0;

    float cubeWidth;
    float cubeHeight;
    float cubeDepth;

    public float cubeScale = 0.3f;
    // Start is called before the first frame update
    void Awake()
    {
        cubeWidth = transform.localScale.z;
        cubeHeight = transform.localScale.y;
        cubeDepth = transform.localScale.x;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        mesh.gameObject.GetComponent<Transform>().localScale = new Vector3(cubeScale, cubeScale, cubeScale);
        CreateCube();
    }




    void CreateCube()
    {
        float startY = cubeHeight / 2f;
        float startX = cubeDepth / 2f;
        float startZ = cubeWidth / 2f;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        for (float z = 0; z < cubeWidth; z += cubeScale)
        {

            for (float y = 0; y < cubeHeight; y += cubeScale)
            {
                for (float x = 0; x < cubeDepth; x += cubeScale)
                {
                    Vector3 vec = transform.localPosition;
                    GameObject cubes = (GameObject)Instantiate(mesh, vec + new Vector3(x - startX, y - startY, z - startZ), Quaternion.identity);
                    cubes.gameObject.GetComponent<MeshRenderer>().material = gameObject.GetComponent<MeshRenderer>().material;
                    numOfCubes++;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
