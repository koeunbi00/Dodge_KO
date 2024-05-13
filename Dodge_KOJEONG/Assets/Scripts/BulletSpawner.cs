using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;


    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;

    // 환호 사운드를 저장할 변수
    public AudioClip cheerSound;

    // AudioSource 컴포넌트를 저장할 변수
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;
        // AudioSource 컴포넌트 초기화
        audioSource = gameObject.AddComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if(timeAfterSpawn >= spawnRate){
            timeAfterSpawn = 0f;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }

    private void Die()
    {
        // 환호 사운드 재생
        if (cheerSound != null)
        {
            audioSource.PlayOneShot(cheerSound);
        }
    }

}
