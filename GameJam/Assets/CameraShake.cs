using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.position;

        float time = 0f;

        while(time < duration)
        {
            float xOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            float yOffset = Random.Range(-0.5f, 0.5f) * magnitude;

            transform.position = new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z);

            time += Time.deltaTime;

            yield return null;
        }

        transform.position = originalPosition;
    }
}
