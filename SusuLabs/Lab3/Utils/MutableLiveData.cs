namespace SusuLabs.Lab3.Utils;

public class MutableLiveData<T> : LiveData<T>
{
    private T? _value;
    private HashSet<LiveData<T>.OnDataChanged> _listeners = new();

    public T? Value
    {
        get => _value;
        set
        {
            if (value == null) return;
            _value = value;

            foreach (var listener in _listeners)
            {
                listener(value);
            }
        }
    }

    public MutableLiveData(T value)
    {
        _value = value;
    }
    
    public MutableLiveData() {}

    public void RemoveObserver(LiveData<T>.OnDataChanged listener)
    {
        _listeners.Remove(listener);
    }

    public void Observe(LiveData<T>.OnDataChanged listener)
    {
        _listeners.Add(listener);
    }
}