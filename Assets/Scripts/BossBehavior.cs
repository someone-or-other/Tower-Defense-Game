using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    GameObject minionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnMinions()
    {
        for(int i = 0; i < 5; i++)
        {
            Instantiate(minionPrefab, new Vector3(-42, 15, transform.position.z), Quaternion.identity);
            float ratio = i * 1f / (5 - 1);
            float timeToWait = Mathf.Lerp(0.5f, 1.5f, 1 - ratio);
            yield return new WaitForSeconds(timeToWait);
        }
    }
}
