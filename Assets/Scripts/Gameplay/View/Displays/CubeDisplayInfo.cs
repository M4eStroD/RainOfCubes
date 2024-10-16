public class CubeDisplayInfo : Display
{
    protected override void Awake()
    {
        base.Awake();

        _spawnersLogic.CubeAdded += IncreaseActiveItem;
        _spawnersLogic.CubeAdded += IncreaseCreatedItem;
        _spawnersLogic.CubeAdded += IncreaseItemAllTime;
        
        _spawnersLogic.CubeRemoved += DecreaseActiveItem;
        
        _spawnersLogic.CubeSpawned += IncreaseItemAllTime;
        _spawnersLogic.CubeSpawned += IncreaseActiveItem;
    }

    private void OnDisable()
    {
        _spawnersLogic.CubeAdded -= IncreaseActiveItem;
        _spawnersLogic.CubeAdded -= IncreaseCreatedItem;
        _spawnersLogic.CubeAdded -= IncreaseItemAllTime;
        
        _spawnersLogic.CubeRemoved -= DecreaseActiveItem;
        
        _spawnersLogic.CubeSpawned -= IncreaseItemAllTime;
        _spawnersLogic.CubeSpawned -= IncreaseActiveItem;
    }    
}