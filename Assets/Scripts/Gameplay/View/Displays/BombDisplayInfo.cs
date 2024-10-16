public class BombDisplayInfo : Display
{
    protected override void Awake()
    {
        base.Awake();

        _spawnersLogic.BombAdded += IncreaseActiveItem;
        _spawnersLogic.BombAdded += IncreaseCreatedItem;
        _spawnersLogic.BombAdded += IncreaseItemAllTime;
        
        _spawnersLogic.BombRemoved += DecreaseActiveItem;
        
        _spawnersLogic.BombSpawned += IncreaseItemAllTime;
        _spawnersLogic.BombSpawned += IncreaseActiveItem;
    }

    private void OnDisable()
    {
        _spawnersLogic.BombAdded -= IncreaseActiveItem;
        _spawnersLogic.BombAdded -= IncreaseCreatedItem;
        _spawnersLogic.BombAdded -= IncreaseItemAllTime;
        
        _spawnersLogic.BombRemoved -= DecreaseActiveItem;
        
        _spawnersLogic.BombSpawned -= IncreaseItemAllTime;
        _spawnersLogic.BombSpawned -= IncreaseActiveItem;
    }
}