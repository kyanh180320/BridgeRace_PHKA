using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constants.TAG_CHARACTER))
        {
            print("va cham nguoi choi");
        }
    }
}
