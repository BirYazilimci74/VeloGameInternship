using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject[] leftObstacles;
    [SerializeField] private GameObject[] middleObstacles;
    [SerializeField] private GameObject[] rightObstacles;
    
    [Header("SpawnTransforms")]
    [SerializeField] private Transform spawnTransformLeft;
    [SerializeField] private Transform spawnTransformMiddle;
    [SerializeField] private Transform spawnTransformRight;

    private List<GameObject> leftObstaclePool;
    private List<GameObject> middleObstaclePool;
    private List<GameObject> rightObstaclePool;
    
    
    private void Awake()
    {
        leftObstaclePool = ArrayToList(leftObstacles);
        middleObstaclePool = ArrayToList(middleObstacles);
        rightObstaclePool = ArrayToList(rightObstacles);
    }

    private void Start()
    {
        StartCoroutine(GenerateObtacle());
    }

    private IEnumerator GenerateObtacle()
    {
        while (true)
        {   
            GetObstacles();
            yield return new WaitForSeconds(GameManager.Instance.obstacleSpawnDelay);
        }
    }
    
    private void GetObstacles()
    {
        if (!GameManager.Instance.canPlay){return;}
        
        GameObject[] gameObjects = SetObstacle();

        gameObjects[0].SetActive(true);
        gameObjects[0].transform.position = spawnTransformLeft.position;
        
        gameObjects[1].SetActive(true);
        gameObjects[1].transform.position = spawnTransformMiddle.position;
        
        gameObjects[2].SetActive(true);
        gameObjects[2].transform.position = spawnTransformRight.position;
    }
    
    private GameObject[] SetObstacle()
    {
        GameObject[] gameObjects = new GameObject[3];
        
        do
        {
            int index0 = Random.Range(0,leftObstaclePool.Count);
            gameObjects[0] = leftObstaclePool[index0];

        } while (gameObjects[0].activeSelf);
        
        do
        {
            int index1 = Random.Range(0,middleObstaclePool.Count);
            gameObjects[1] = middleObstaclePool[index1];
            
        } while (gameObjects[1].activeSelf);
        
        do
        {
            int index2 = Random.Range(0,rightObstaclePool.Count);
            gameObjects[2] = rightObstaclePool[index2];
            
        } while (gameObjects[2].activeSelf);

        return gameObjects;
    }


    private List<GameObject> ArrayToList(GameObject[] obstacles)
    {
        List<GameObject> list = new List<GameObject>();
        foreach (GameObject gameObject in obstacles)
        {
            GameObject newGameObject = Instantiate(gameObject,Vector3.zero,Quaternion.identity);
            newGameObject.SetActive(false);
            list.Add(newGameObject);
        }
        return list;
    }
}
