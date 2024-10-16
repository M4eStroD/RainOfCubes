using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    [SerializeField] protected SpawnersLogic _spawnersLogic;

    [SerializeField] protected Text _countAllTimeText;
    [SerializeField] protected Text _countCreatedText;
    [SerializeField] protected Text _countActiveText;

    protected virtual void Awake()
    {
        _countAllTimeText.text = 0.ToString();
        _countCreatedText.text = 0.ToString();
        _countActiveText.text = 0.ToString();
    }

    protected void IncreaseActiveItem()
    {
        int.TryParse(_countActiveText.text, out int result);

        _countActiveText.text = (++result).ToString();
    }

    protected void DecreaseActiveItem()
    {
        int.TryParse(_countActiveText.text, out int result);

        _countActiveText.text = (--result).ToString();
    }

    protected void IncreaseCreatedItem()
    {
        int.TryParse(_countCreatedText.text, out int result);

        _countCreatedText.text = (++result).ToString();
    }

    protected void IncreaseItemAllTime()
    {
        int.TryParse(_countAllTimeText.text, out int result);

        _countAllTimeText.text = (++result).ToString();
    }
}