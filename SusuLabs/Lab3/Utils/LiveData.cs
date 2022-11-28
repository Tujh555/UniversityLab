namespace SusuLabs.Lab3.Utils;

public interface ILiveData<T>
{
    public delegate void OnDataChanged(T data);

    public T? Value { get; }

    public void RemoveObserver(OnDataChanged listener);

    public void Observe(OnDataChanged listener);
}