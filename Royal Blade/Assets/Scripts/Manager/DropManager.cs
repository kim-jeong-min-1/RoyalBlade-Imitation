using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : Singleton<DropManager>
{
    public Queue<DropObject> dropQueue = new Queue<DropObject>();

    [SerializeField] private List<DropObject> dropObjects;
    [SerializeField] private Transform dropObjectGroup;
    [SerializeField] private Transform spawnPoint;
    private float spawnCount;

    [SerializeField] private float defalutHp;
    [SerializeField] private float waveTime;
    [SerializeField] private float defaultWaveDelay;
    private float waveDelayMultiply;

    public void WaveStart(int waveLevel)
    {
        waveDelayMultiply = defaultWaveDelay / waveLevel;
        StartCoroutine(Wave(waveTime, waveDelayMultiply, defalutHp, waveLevel));
    }

    private IEnumerator Wave(float waveTime, float waveDelay, float Hp, float level)
    {
        float curTime = 0;
        float maxTime = waveTime;
        int count;

        while (curTime < maxTime)
        {
            count = Random.Range(4, 10);
            Debug.Log(count);

            for (int i = 0; i < count; i++)
            {
                DropObject dropObject = Instantiate((spawnCount % 2 == 0) ? dropObjects[0] : dropObjects[1], 
                    spawnPoint.position, Quaternion.identity, dropObjectGroup);
                dropObject.DropObjectInit(Hp, level);
                dropQueue.Enqueue(dropObject);

                yield return WaitManager.GetWait(0.5f);
                spawnCount++;
                curTime += 0.5f;
            }     

            float delay = waveDelay + Random.Range(1f, 2f);
            yield return WaitManager.GetWait(delay);

            curTime += delay;
        }
    }
}
