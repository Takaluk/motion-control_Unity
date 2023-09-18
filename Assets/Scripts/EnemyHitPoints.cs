using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitPoints : MonoBehaviour
{
    public float waitTime = 1;

    public bool EnemyArrived = false;
    public AudioSource audioSource;
    public AudioClip[] enemyDieSounds;
    public AudioClip[] attackSounds;
    public AudioClip[] sliceSounds;


    public void Die()
    {
        print("EnemyDead");
        audioSource.PlayOneShot(sliceSounds[Random.Range(0, sliceSounds.Length)]);
        audioSource.PlayOneShot(enemyDieSounds[Random.Range(0, enemyDieSounds.Length)]);
        GameManager.instance.AddScore(1);
        EnemyArrived = false;
    }

    public void EnemyAttack() 
    {
        StartCoroutine(WaitForPlayerAttack());
        waitTime -= 0.01f;
    }

    private IEnumerator WaitForPlayerAttack()
    {
        audioSource.PlayOneShot(attackSounds[Random.Range(0, attackSounds.Length)]);

        float timer = 0f;

        while (timer < waitTime)
        {
            timer += Time.deltaTime;

            if (!EnemyArrived)
            {
                yield break;
            }

            yield return null;
        }

        audioSource.PlayOneShot(attackSounds[Random.Range(0, attackSounds.Length)]);

        GameManager.instance.GameOver();
    }
}
