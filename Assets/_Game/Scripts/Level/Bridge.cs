using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform stairPrefab;
    public Transform stairs;
    public int amountStair;
    public float distanceY;
    public float distanceZ;

    public List<Transform> stairsList = new List<Transform>();
    void Start()
    {
        SpawnStair();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SpawnStair()
    {
        for (int j = 0; j < stairsList.Count; j++)
        {
            for (int i = 0; i < amountStair; i++)
            {
                Transform stairClone = Instantiate(stairPrefab, stairsList[j]);
                //stairsList.Add(stairClone);
                stairClone.gameObject.transform.localPosition = new Vector3(0, 0, i * 1.1f);
            }
        }
        
    }
}
