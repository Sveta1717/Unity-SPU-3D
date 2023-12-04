using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint1Script : MonoBehaviour
{
    [SerializeField]
    private Image image;

    private AudioSource collectSound;
    private AudioSource destroySound;

    private float time = 10f;
    private float leftTime;

    private void Start()
    {
        leftTime = time;
        GameState.isCheckPoint1 = false;
        AudioSource[] sources = GetComponents<AudioSource>();
        collectSound = sources[0];
        destroySound = sources[1];
    }

    void LateUpdate()
    {
        leftTime -= Time.deltaTime;
        image.fillAmount = leftTime / time;
        if (leftTime < 0)
        {
            StartCoroutine(DestroyAfterSound());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // спрацювання чекпоїнту - включаємо "бонус"
        collectSound.Play();
        GameState.isCheckPoint1 = true;
        StartCoroutine(DestroyAfterSound());
    }

    IEnumerator DestroyAfterSound()
    {
        // Затримка перед руйнуванням об'єкту
        yield return new WaitForSeconds(destroySound.clip.length);

        // Руйнуємо об'єкт
        Destroy(gameObject);
    }
}