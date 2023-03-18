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

    private static List<Vector3> _particlesPositions = new List<Vector3>
    {
        new Vector3(-1.06f, 1.9948f, 0f),
        new Vector3(1.23f, 1.9948f, 0f),
        new Vector3(0.07f, 1.9948f, -1.444f)
    };

    // Метод вызывается из Interaction при клике на объект
    public void Hit()
    {
        var particle = Instantiate(_particlePrefab, _particlesPositions[Random.Range(0, 3)], Quaternion.identity);
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
