using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitPoints : MonoBehaviour
{
    public bool EnemyArrived = false;
    public AudioSource audioSource;
    public AudioClip[] enemyDieSounds;
    public AudioClip[] attackSounds;


    public void Die()
    {
        print("EnemyDead");
        audioSource.PlayOneShot(enemyDieSounds[Random.Range(0, enemyDieSounds.Length)]);
        GameManager.instance.AddScore(1);
        EnemyArrived = false;
    }

    public void EnemyAttack() 
    {
        StartCoroutine(WaitForSpaceKeyPress());
    }

    private IEnumerator WaitForSpaceKeyPress()
    {
        audioSource.PlayOneShot(attackSounds[Random.Range(0, attackSounds.Length)]);

        float timer = 0f;
        float waitTime = 2f;

        while (timer < waitTime)
        {
            timer += Time.deltaTime;

            if (!EnemyArrived)
            {
                yield break;
            }

            yield return null;
        }

        GameManager.instance.GameOver();
    }
}
