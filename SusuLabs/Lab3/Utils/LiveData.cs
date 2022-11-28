namespace SusuLabs.Lab3.Utils;

/// <summary>
/// Типичная реализация паттерна наблюдатель.
/// Оповещает всех подписчиков об изменении данных в Value
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ILiveData<T>
{
    public delegate void OnDataChanged(T data);

    public T? Value { get; }

    public void RemoveObserver(OnDataChanged listener);

    public void Observe(OnDataChanged listener);
}