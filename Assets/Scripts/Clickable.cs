using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    [SerializeField] private AnimationCurve _scaleCurve;
    [SerializeField] private float _scaleTime = 0.25f;
    [SerializeField] private HitEffect _hitEffectPrefab;
    [SerializeField] private Resources _resources;
    [SerializeField] private Hoverable _particlePrefab;

    private int _coinsPerClick = 1;

    private static Vector3 _particlesPosition = new(0f, 2.14f, 0f);

    // Метод вызывается из Interaction при клике на объект
    public void Hit()
    {
        var particle = Instantiate(_particlePrefab, _particlesPosition, Quaternion.identity);
        particle.SetResources(_resources);
        StartCoroutine(HitAnimation());
    }

    // Анимация колебания куба
    private IEnumerator HitAnimation()
    {
        for (float t = 0; t < 1f; t += Time.deltaTime / _scaleTime)
        {
            float scale = _scaleCurve.Evaluate(t);
            transform.localScale = Vector3.one * scale;
            yield return null;
        }
        transform.localScale = Vector3.one;
    }

    // Этот метод увеличивает количество монет, получаемой при клике
    public void AddCoinsPerClick(int value)
    {
        _coinsPerClick += value;
    }

}
