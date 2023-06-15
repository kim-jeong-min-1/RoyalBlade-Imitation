using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private TextMesh text;

    public IEnumerator DamageText_Update(float damage, System.Action<DamageText> returnText = null)
    {
        float curTime = 0f;
        float time = 1.5f;
        text.text = $"{damage}";

        while (curTime < time)
        {
            transform.Translate(Vector2.up * speed * Time.unscaledDeltaTime);

            Color color = text.color;
            color.a = Mathf.Lerp(1, 0, curTime / time);
            text.color = color;

            curTime += Time.unscaledDeltaTime;
            yield return new WaitForEndOfFrame();
        }
        returnText?.Invoke(this);
    }
}
