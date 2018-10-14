[System.Serializable]
public class LevelData
{
    public int time;
    public Tile[] options;
    public Tile[] items;
    public int answer;

    public LevelData(int _time, Tile[] _options, Tile[] _items)
    {
        time = _time;
        options = _options;
        items = _items;
    }
}