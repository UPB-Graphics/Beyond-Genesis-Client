using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class LabGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject street;
    public List<GameObject> housesPrefabs = new List<GameObject>();
    public List<GameObject> potionsPrefabs = new List<GameObject>();
    public List<GameObject> points = new List<GameObject>();
    public List<GameObject> trees = new List<GameObject>();
    public NavMeshSurface surface;
    public const float distance = 30f;
    public const float factor = 3.5f;

    private const int pointType = 1;
    private const int coinType = 0;
    private const int houseType = 0;
    private const int treeHouseType = 3;
    private Vector3 player_start_position;
    private Transform ground;  
    private static int dimX;
    private static int dimZ;
    private static int playerX = 0;
    private static int playerZ = 0;
    private int elemType;
    private int totalCoins = 0;
    private int nrOfCakes = 0;
    private int nrOfDonuts = 0;
    private int nrOfHamburger = 0;
    private int nrOfHamEgg = 0;
    private int nrOfIceCream = 0;
    private int nrOfMilk = 0;
    private int nrOfWaffle = 0;
    private const int nrOfPotions = 4;
    private  int limitFood = 10;
    private int limitCoins = 50;
    private int food = 0;
    public List<Coordinate> positionsOfPotions = new List<Coordinate>();
    public static Stopwatch timer = new Stopwatch();

    private string sceneName = "SecondScene3";    

    private void drawTrees() {

        Vector3 position;
        GameObject element;
        int treeType;

         for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 20; j++) {
                position = transform.position + new Vector3(2f*i-45, 0, 24-2f*j);
                treeType = Random.Range(0, 3);
                element = Instantiate(trees[treeType], position, Quaternion.Euler(0, 90, 0), ground.transform);
                element.transform.localScale = new Vector3(4f, 5f, 4f);

            }
        }

        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 25; j++) {
                position = transform.position + new Vector3(2f*i+42, 0, 22-2f*j);
                treeType = Random.Range(0, 3);
                element = Instantiate(trees[treeType], position, Quaternion.Euler(0, 90, 0), ground.transform);
                element.transform.localScale = new Vector3(4f, 5f, 4f);

            }
        }

        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 25; j++) {
                position = transform.position + new Vector3(2f*j-25, 0, 45-2f*i);
                treeType = Random.Range(0, 3);
                element = Instantiate(trees[treeType], position, Quaternion.Euler(0, 90, 0), ground.transform);
                element.transform.localScale = new Vector3(4f, 5f, 4f);

            }
        }

        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 25; j++) {
                position = transform.position + new Vector3(2f*j-25, 0, 2f*i-45);
                treeType = Random.Range(0, 3);
                element = Instantiate(trees[treeType], position, Quaternion.Euler(0, 90, 0), ground.transform);
                element.transform.localScale = new Vector3(4f, 5f, 4f);

            }
        }
    }

    private void drawPoint(int i, int j) {

        Vector3 position;
        GameObject element;
        Vector3 scale = new Vector3(1f, 1f, 1f);
        int type;

        type = Random.Range(0, points.Count);
        //print("Point type initial: " + type);
        if (food > 5) {
            type = coinType;
            food = 0;
        }
        
        //enough money => generate another number
        if ((type == coinType) && (totalCoins > limitCoins)) {
            type = Random.Range(1, points.Count);
        } 

        switch(type) {
            case 0:
                totalCoins++;
                scale = new Vector3(0.4f, 0.8f, 0.8f);
                break;
            case 1:
                if (nrOfCakes > limitFood) {
                    type = type - 1;
                    goto case 0;
                }
                nrOfCakes++;
                food++;
                scale = new Vector3(3f, 3f, 3f);
                break;
            case 2:
                if (nrOfDonuts > limitFood) {
                    type = type - 1;
                    goto case 1;
                }
                food++;
                nrOfDonuts++;
                scale = new Vector3(3f, 3f, 3f);
                break;
            case 3:
                if (nrOfHamburger > limitFood) {
                    type = type - 1;
                    goto case 2;
                }
                nrOfHamburger++;
                food++;
                scale = new Vector3(3f, 3f, 3f);
                break;
            case 4:
                if (nrOfHamEgg > limitFood) {
                    type = type + 1;
                    goto case 5;
                }
                nrOfHamEgg++;
                food++;
                scale = new Vector3(3f, 3f, 3f);
                break;
            case 5:
                if (nrOfIceCream > limitFood) {
                    type = type + 1;
                    goto case 6;
                }
                nrOfIceCream++;
                food++;
                scale = new Vector3(3f, 3f, 3f);
                break;
            case 6:
                if (nrOfMilk > limitFood) {
                    type = type + 1;
                    goto case 7;
                }
                nrOfMilk++;
                food++;
                scale = new Vector3(3f, 3f, 3f);
                break;
            case 7:
                if (nrOfWaffle > limitFood) {
                    type = 3;
                    goto case 3;
                }
                nrOfWaffle++;
                food++;
                scale = new Vector3(3f, 3f, 3f);
                break;
        }
        //print("Point type final: " + type);
        position = transform.position + new Vector3(factor*i-distance, 0.5f, factor*j-distance);
        element = Instantiate(points[type], position, Quaternion.Euler(0, 90, 0), ground.transform);
        element.transform.localScale = scale;
        var flags = StaticEditorFlags.OccluderStatic | StaticEditorFlags.OccludeeStatic;
        GameObjectUtility.SetStaticEditorFlags(element, flags);

        //draw piece of street
        position = transform.position + new Vector3(factor*i-distance, 0.1f, factor*j-distance);
        element = Instantiate(street, position, Quaternion.Euler(0, 90, 0), ground.transform);
        if (i % 2 == 0) {
            element.transform.localScale = new Vector3(1f, 0.5f, 0.5f);
        } else {
            element.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        }
    }

Vector3 houseScale = new Vector3(0.4f, 0.6f, 0.4f);

private void drawHouse(int i, int j, int type) {

    Vector3 position;
    GameObject element;
    
    if (type == 0) {
        type = Random.Range(0, housesPrefabs.Count-1);
        position = transform.position + new Vector3(factor*i-distance, 0, factor*j-distance);
        element = Instantiate(housesPrefabs[type], position, Quaternion.Euler(0, 90, 0), ground.transform);
        element.transform.localScale = houseScale;
    }
    else
    {
        position = transform.position + new Vector3(factor*i-distance, 0, factor*j-distance);
        element = Instantiate(housesPrefabs[type], position, Quaternion.Euler(0, 90, 0), ground.transform);
    }
    
}

    //true - free postion; false -  ocupied position
    private bool checkPosition(int x, int z) {

        if (x == playerX && z == playerZ) {
            return false;
        }

        for (int i = 0; i < positionsOfPotions.Count; i++) {
            if (x == positionsOfPotions[i].x && z == positionsOfPotions[i].z){
                return false;
            }
        }
        return true;
    }

Vector3 potionScale = new Vector3(3f, 3f, 3f);


    private void drawPotions() {

        Vector3 position;
        GameObject element;
        Coordinate coordinate;
        int x, z;

        for (int i = 0; i < nrOfPotions; i++) {
            x = Random.Range(0, dimX);
            z = Random.Range(0, dimZ);
            while (!checkPosition(x, z)) {
                x = Random.Range(0, dimX);
                z = Random.Range(0, dimZ);
            }
            coordinate = new Coordinate(x, z);
            positionsOfPotions.Add(coordinate);
            position = transform.position + new Vector3(factor*x-distance, -1f, factor*z-distance);
            element = Instantiate(potionsPrefabs[i], position, Quaternion.Euler(0, 90, 0), ground.transform);
            element.transform.localScale = potionScale;

            //draw piece of street
            position = transform.position + new Vector3(factor*x-distance, 0.1f, factor*z-distance);
            element = Instantiate(street, position, Quaternion.Euler(0, 90, 0), ground.transform);
            if (x % 2 == 0) {
                element.transform.localScale = new Vector3(1f, 0.5f, 0.5f);
            } else {
                element.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
            }
        }

    }

    private void drawTree(int i, int j) {

        Vector3 position;
        GameObject element;
        int treeType;

        position = transform.position + new Vector3(factor*i-distance, 0, factor*j-distance);
        treeType = Random.Range(0, trees.Count);
        element = Instantiate(trees[treeType], position, Quaternion.Euler(0, 90, 0), ground.transform);
        if (treeType > 2) {
            element.transform.localScale = new Vector3(0.1f, 0.15f, 0.1f);
        }
        else
        {
            element.transform.localScale = new Vector3(5f, 5f, 5f);
        }
    }

    
    int min = 15;
    int max = 22;

    Vector3 playerPositon = new Vector3(3.5f*playerX-distance, 0.12f, 3.5f*playerZ-distance);
    Vector3 playerScale = new Vector3(0.1f, 0.2f, 0.1f);

    void Awake() {

        Vector3 position;
        GameObject element;
        int treeType;
        int lastElemType = -1; 
        int nrOfHouses = 0;
        int nrOfPoints = 0;

        dimX = Random.Range(min, max);
        dimZ = Random.Range(min, max);
        limitCoins = (int) (dimX * dimZ)/5;
        limitFood = (int) (dimX * dimZ)/18;
        ground = transform;

        //print("X:" + dimX + "   Y:" + dimZ);   
        

        //place the potions
        drawPotions();


        for (int i = 0; i < dimX; i++) {
            nrOfHouses = 0;
            nrOfPoints = 0;
            for (int j = 0; j < dimZ; j++) {

                if(!checkPosition(i, j)) {
                    continue;
                }


                if (i % 2 == 0) {
                    drawPoint(i, j);
                    continue;
                }

                elemType = Random.Range(0,4);

                // limit the number of coins to maximum dimZ/3
                if ((elemType == pointType && nrOfPoints > dimZ/3) || lastElemType == pointType) { 
                    while(elemType == 1) {
                        elemType = Random.Range(0,4);
                    }
                }
                
                // limit the number of houses to maximum half of dimZ
                if ((elemType == houseType || elemType == treeHouseType) && nrOfHouses > dimZ/2) {
                    
                    if (nrOfPoints > dimZ/3) {
                        elemType = 2;
                    }
                    else {
                        while (elemType == treeHouseType) {
                            elemType = Random.Range(1,4);
                        }
                    }
                }

                lastElemType = elemType;

                switch(elemType) {
                    case 0:
                        drawHouse(i, j, 0);
                        nrOfHouses++;
                        break;
                    case 1:
                        drawPoint(i, j);
                        nrOfPoints++;
                        break;
                    case 2:
                        drawTree(i, j);
                        break;
                    case 3:
                        if (j % 2 == 0)
                            drawHouse(i, j, housesPrefabs.Count-1);
                        else
                            drawHouse(i, j, 0);
                        nrOfHouses++;
                        break;

                }
            }
        }

        drawTrees();   

        surface.BuildNavMesh();
    }

    void Start()
    {
        timer.Start();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
