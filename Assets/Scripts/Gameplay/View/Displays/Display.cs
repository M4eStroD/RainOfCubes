using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    [SerializeField] private Text _cuntAllTimeText;
    [SerializeField] private Text _countCreatedText;
    [SerializeField] private Text _countActiveText;

    private void Awake()
    {
        _cuntAllTimeText.text = 0.ToString();
        _countCreatedText.text = 0.ToString();
        _countActiveText.text = 0.ToString();
    }

    private void OnEnable()
    {
        _spawner.InfoChanged += UpdateInfo;
    }

    private void OnDisable()
    {
        _spawner.InfoChanged -= UpdateInfo;
    }

    private void UpdateInfo()
    {
        _cuntAllTimeText.text = _spawner.EntityAllTime.ToString();
        _countCreatedText.text = _spawner.EntityCreated.ToString();
        _countActiveText.text = _spawner.EntityActive.ToString();
    }
}