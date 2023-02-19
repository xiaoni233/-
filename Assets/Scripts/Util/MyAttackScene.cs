using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAttackScene : MonoBehaviour
{
    private static MyAttackScene instance;
    public static MyAttackScene Instance
    {
        get
        {
            if (instance == null)
                instance = Transform.FindObjectOfType<MyAttackScene>();
            return instance;
        }
    }
    private bool isShake;

    public void HitPause(int duration)
    {
        Debug.Log("HitPause");
        StartCoroutine(Pause(duration));
    }

    IEnumerator Pause(int duration)
    {
        float pauseTime = duration / 60f;
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(pauseTime);
        Time.timeScale = 1;
    }

    public void CameraShake(float duration, float strength)
    {
        Debug.Log("CameraShake");
        if (!isShake)
            StartCoroutine(Shake(duration, strength));
    }

    IEnumerator Shake(float duration, float strength)
    {
        isShake = true;
        Transform camera = Camera.main.transform;
        Vector3 startPosition = camera.position;

        while (duration > 0)
        {
            camera.position = Random.insideUnitSphere * strength + startPosition;
            duration -= Time.deltaTime;
            yield return null;
        }
        camera.position = startPosition;
        isShake = false;
    }
}
