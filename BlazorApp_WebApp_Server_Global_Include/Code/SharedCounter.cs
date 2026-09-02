namespace BlazorApp_WebApp_Server_Global_Include.Code;

public class SharedCounter
{
    private int _count;
    public int Count => _count;
    // událost, která se vyvolá při změně počtu
    // událost je typu Action, což znamená, že nevrací žádnou hodnotu a nemá žádné parametry
    public event Action? CountChanged;
    public void Increment()
    {
        // _count++;
        // lepší řešení pro thread safety
        Interlocked.Increment(ref _count);
        CountChanged?.Invoke();
    }
}
