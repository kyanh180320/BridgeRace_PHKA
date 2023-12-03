using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public ColorData colorData;
    public Brick brickPrefab;
    public float columnSpacing = 2f;
    public float rowSpacing = 2f;
    public int columns, rows;
    public List<Brick> listBricks = new List<Brick>();
    public List<ColorType> initColorTypes= new List<ColorType>();

    public Transform finishPoint;

    public Transform bricksSpawner;
    void Awake()
    {
        LevelManager.Ins.OnInit();

        if (colorData != null && brickPrefab != null)
        {
            SpawnBricks();
        }
        else
        {
            Debug.LogError("Vui lòng gán ColorData và Brick Prefab trong Inspector.");
        }
    }
  

    public void SpawnBricks()
    {


        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                float spawnX = i * columnSpacing;
                float spawnZ = j * rowSpacing;

            
                Brick brickClone = Instantiate(brickPrefab, bricksSpawner);
                brickClone.gameObject.SetActive(false);
                listBricks.Add(brickClone);
                brickClone.gameObject.transform.localPosition = new Vector3(spawnX, 0f, spawnZ);

                int randomColor = Random.Range(0, LevelManager.Ins.colorSpawnBrick.Count);
                brickClone.ChangeColor(LevelManager.Ins.colorSpawnBrick[randomColor]);


            }
        }
    }
    public void GetBricskPos(ColorType colorType, Character character)
    {
        Brick brick = null;
        for (int i = 0; i < listBricks.Count; i++)
        {
            brick = listBricks[i];
            if (brick.colorType == colorType)
            {
                brick.gameObject.SetActive(true);
                character.listBricksTrueColor.Add(brick);
            }
        }
    }




}
