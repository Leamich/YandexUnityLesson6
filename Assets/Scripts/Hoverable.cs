using UnityEngine;

public class Hoverable : MonoBehaviour
{
    [SerializeField] private AnimationCurve _scaleCurve;
    [SerializeField] private HitEffect _hitEffectPrefab;
    [SerializeField] private float _xForce = 1f;
    [SerializeField] private float _yForce = 1f;
    [SerializeField] private float _zForce = 1f;

    private Resources _resources;
    private int _coinsPerClick = 1;
    private Rigidbody _rigidbody;

    public void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(new(_xForce * (Random.value * 2 - 1), _yForce, _zForce * Random.value));
        //_rigidbody.AddExplosionForce(_yForce, transform.position, _xForce);
    }

    public void SetResources(Resources resources)
    {
        _resources = resources;
    } 

    public void OnHover()
    {
        HitEffect hitEffect = Instantiate(_hitEffectPrefab, transform.position, Quaternion.identity);
        hitEffect.Init(_coinsPerClick);
        _resources.CollectCoins(1, transform.position);
        Destroy(gameObject);
    }
}
