using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    // Start is called before the first frame update
    public List<Character> characterList = new List<Character>();
    public List<ColorType> colorSpawnBrick = new List<ColorType>();
    public ColorData colorData;
    public List<Bot> bots = new List<Bot>();
    public int levelIndex;
    public Level[] levelPrefabs;
    private Level currentLevel;


    private void Awake()
    {
        levelIndex = PlayerPrefs.GetInt("Level", 0);
    }
    public void OnInit()
    {
        ColorType[] allValues = (ColorType[])System.Enum.GetValues(typeof(ColorType));

        for (int i = 0; i < characterList.Count; i++)
        {
            ColorType colorType = allValues[i + 1];
            colorSpawnBrick.Add(colorType);
            characterList[i].colorType = colorType;
            Material material = colorData.GetColorMaterial(colorType);
            characterList[i].ApplyMaterial(material);

        }
    }
    private void Start()
    {
        UIManager.Ins.OpenUI<MainMenu>();
        LoadLevel(levelIndex);
    }

    public void OnStartGame()
    {
        GameManager.Ins.ChangeState(GameState.Gameplay);
        for (int i = 0; i < bots.Count; i++)
        {
            bots[i].ChangeState(new PatrolState());
        }
    }
    public void OnReset()
    {
        for (int i = 0; i < characterList.Count; i++)
        {
            characterList[i].gameObject.SetActive(false);
            characterList[i].RemoveAllBrick();
            characterList[i].ClearListBricksTrueColor();

            characterList[i].ChangeAnim(Constants.ANIM_IDLE);
            characterList[i].transform.eulerAngles = new Vector3(0, 0, 0);
            characterList[i].transform.position = currentLevel.startPos.position + new Vector3(5*i, 0,0);
            characterList[i].gameObject.SetActive(true);
        }
    }
    public void OnRetry()
    {
        OnReset();
        LoadLevel(levelIndex);
        UIManager.Ins.OpenUI<MainMenu>();
    }
    public void OnNextLevel()
    {
       

        levelIndex++;
        PlayerPrefs.SetInt("Level", levelIndex);
        LoadLevel(levelIndex);
        OnReset();

        UIManager.Ins.OpenUI<MainMenu>();
        GameManager.Ins.ChangeState(GameState.MainMenu);
    }

    public void OnFinishGame()
    {
        for (int i = 0; i < bots.Count; i++)
        {
            bots[i].gameObject.SetActive(false);
            bots[i].RemoveAllBrick();
            bots[i].ClearListBricksTrueColor();
        }
    }
    public void LoadLevel(int level)
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
        }

        if (level < levelPrefabs.Length)
        {
            currentLevel = Instantiate(levelPrefabs[level]);
            //currentLevel.OnInit();
        }
        else if(level == levelPrefabs.Length)
        {
            levelIndex = 0;
            PlayerPrefs.SetInt("Level", 0);
        }
    }
}
