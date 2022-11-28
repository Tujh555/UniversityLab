namespace SusuLabs.Lab3.Utils;

public class MutableLiveData<T> : ILiveData<T>
{
    private T? _value;
    private HashSet<ILiveData<T>.OnDataChanged> _listeners = new();

    public T? Value
    {
        get => _value;
        set
        {
            if (value == null) return;
            
            if (_value?.Equals(value) ?? false) return;
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

    public void RemoveObserver(ILiveData<T>.OnDataChanged listener)
    {
        _listeners.Remove(listener);
    }

    public void Observe(ILiveData<T>.OnDataChanged listener)
    {
        _listeners.Add(listener);
    }
}