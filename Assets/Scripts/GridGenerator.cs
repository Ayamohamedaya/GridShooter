using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GridGenerator : MonoBehaviour
{

    public GameObject gridCell;
    [SerializeField]SOFile file;
    public Transform grid;
    private int rowSize=10;
    private int columnSize=5;
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject jumpEnemy;
    Vector3 playerPosition;
    int[,] size;
    int numOfCells;
  // [SerializeField] int numOfenemies;
   //[SerializeField] int numOfJumpenemies;
    [SerializeField] UnityEvent onGridGenerated;

    Vector3 startGrid, endGrid;
    int[] childs;
    private void Awake()
    {
        size = file.ConvertSize();
        GenerateGrid();

    }
    void Initialize()
    {
        rowSize = size[0,0];
        columnSize = size[0,1];
        numOfCells = rowSize * columnSize;

        //columnSize = numOfColumns;
       float stepX = (rowSize/2 ) ;
       float stepZ = (columnSize/2 ) ;
        playerPosition = transform.TransformPoint(stepX, 1, -stepZ);
    }

    public void ClearGrid()
    {
        for (int count = 0; count < grid.childCount; count++)
        {
            Destroy(grid.GetChild(count).gameObject);
        }
    }
    public void GenerateGrid()
    {

        ClearGrid();

        Initialize();

        GameObject cell ;
        for (int i = 0; i < rowSize; i++)
        {
            for (int j=0; j< columnSize;j++)
            {
                Vector3 gridPosition = transform.position + transform.TransformVector(i, 0, -j);
                cell = Instantiate(gridCell,gridPosition,transform.rotation);
                cell.transform.SetParent(grid);
                cell.transform.localScale = Vector3.one;
            }

        }
        onGridGenerated.Invoke();
    }
    public void InstantiatePlayer()
    {
        Instantiate(player,playerPosition,player.transform.rotation);
    }
    public void instantiateEnemy(  int numOfEnemies)
    {
        int num;
        childs = new int[numOfEnemies];
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i] = -1;
        }
        for (int i = 0; i < childs.Length; i++)
        {
            do
            {
                num = Random.Range(0, grid.childCount);
            } while (System.Array.Exists(childs, element => element == num));
            childs[i] = num;
        }
        GameObject enemySpawn;
        for(int i=0;i< numOfEnemies; i++)
        {
            Vector3 enemyPosition = new Vector3(grid.GetChild(childs[i]).transform.position.x
                , 1, grid.GetChild(childs[i]).transform.position.z);
            enemySpawn = Instantiate(enemy,enemyPosition,transform.rotation);
        }
    }
    public void instantiateJumpEnemy(  int numOfEnemies)
    {
        int num;
        childs = new int[numOfEnemies];
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i] = -1;
        }
        for (int i = 0; i < childs.Length; i++)
        {
            do
            {
                num = Random.Range(0, grid.childCount);
            } while (System.Array.Exists(childs, element => element == num));
            childs[i] = num;
        }
        GameObject enemySpawn;
        for(int i=0;i< numOfEnemies; i++)
        {
            Vector3 enemyPosition = new Vector3(grid.GetChild(childs[i]).transform.position.x
                , 1, grid.GetChild(childs[i]).transform.position.z);
            enemySpawn = Instantiate(jumpEnemy,enemyPosition,transform.rotation);
        }
    }

}
