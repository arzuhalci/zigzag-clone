using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoadCreator : MonoBehaviour
{
    public List<GameObject> cubes;
    public GameObject prefab;
    Vector3 pos;
    public GameObject mainCube;
    Plane rightBorder;
    Plane leftBorder;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
        
            randomRoadCreator(1000);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void createCubeZAxis(int times)
    {
        for (int i = 0; i < times; i++)
        {
            if (cubes.Count == 0)
        {
            if (cubes.Find(x => x.name == "MainCube") == null)
            {
                cubes.Add(GameObject.Find("MainCube"));
            }
        }

        pos = new Vector3(cubes.Last<GameObject>().transform.position.x, cubes.Last<GameObject>().transform.position.y, cubes.Last<GameObject>().transform.position.z + 1);


        
            GameObject newGO = (GameObject)Instantiate(prefab, pos, Quaternion.identity);
            cubes.Add(newGO);
        }
        
    }

    public void createCubeXAxis(int times)
    {
        for (int i = 0; i < times; i++)
        {
            if (cubes.Count == 0)
        {
            if (cubes.Find(x => x.name == "MainCube") == null)
            {
                cubes.Add(GameObject.Find("MainCube"));
            }
        }

        pos = new Vector3(cubes.Last<GameObject>().transform.position.x - 1, cubes.Last<GameObject>().transform.position.y, cubes.Last<GameObject>().transform.position.z);


        
            GameObject newGO = (GameObject)Instantiate(prefab, pos, Quaternion.identity);
            cubes.Add(newGO);
        }

    }

    public void randomRoadCreator(int times)
    {
        for (int i = 0; i < times; i++)
        {
            var randomaxis = Random.Range(1, 3);
            var randomamount = Random.Range(1, 3);
            if (cubes.Count != 0) {
                if (checkCollisionToRightBorder())
                {
                    createCubeZAxis(randomamount);
                    
                }

                if (checkCollisionToLeftBorder())
                {
                    createCubeXAxis(randomamount);
                    
                }
            }
            if (checkCollisionToRightBorder())
            {
                
            }
            if (checkCollisionToLeftBorder())
            {
                
            }
                if (randomaxis == 1)
            {
                createCubeXAxis(randomamount);
            }
            if (randomaxis == 2)
            {
                createCubeZAxis(randomamount);
            }

        }
    }

    public bool checkCollisionToRightBorder()
    {
        Plane rightBorder = new Plane(new Vector3(5, 0, 5), Mathf.Sqrt(50));
        if (cubes.Count != 0)
        {
            if (rightBorder.GetDistanceToPoint(cubes.Last<GameObject>().transform.position) <= 3f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public bool checkCollisionToLeftBorder()
    {
        Plane leftBorder = new Plane(new Vector3(-5, 0, -5), Mathf.Sqrt(50));
        if (cubes.Count != 0)
        {
            if (leftBorder.GetDistanceToPoint(cubes.Last<GameObject>().transform.position) <= 3f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

}
