using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    private int lastIndex = -1;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
       
        int index;

        if (prefabs.Length == 1)
        {
            index = 0 ;
        }
        else
        {
            index = Random.Range(0, prefabs.Length);
            while (index == lastIndex)
            {
                index = Random.Range(0, prefabs.Length);
            }
        }
        
        lastIndex = index;

        GameObject pipes = Instantiate(prefabs[index], transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
