using System.Collections;

namespace ExtendedDictionary;


public class ExtendedDictionaryElement<T, U, V>
{
    public T Key { get; set; }
    public U Value1 { get; set; }
    public V Value2 { get; set; }

    public ExtendedDictionaryElement(T key, U value1, V value2)
    {
        Key = key;
        Value1 = value1;
        Value2 = value2;
    }
}

public class ExtendedDictionary<T, U, V> : IEnumerable
{
    public int Count => _elements.Count;
    
    private readonly List<ExtendedDictionaryElement<T, U, V>> _elements;

    public ExtendedDictionary()
    {
        _elements = new List<ExtendedDictionaryElement<T, U, V>>();
    }

    public void Add(T key, U value1, V value2)
    {
        _elements.Add(new ExtendedDictionaryElement<T, U, V>(key, value1, value2));
    }

    public bool ContainsKey(T key)
    {
        return _elements.Any(e => Equals(e.Key, key));
    }

    public U GetValue1(T key)
    {
        return GetElement(key).Value1;
    }

    public V GetValue2(T key)
    {
        return GetElement(key).Value2;
    }
    
    public void Remove(T key)
    {
        _elements.Remove(GetElement(key));
    }

    public bool ContainsValues(U value1, V value2)
    {
        return _elements.Any(e => Equals(e.Value1, value1) && Equals(e.Value2, value2));
    }
    
    
    

    public ExtendedDictionaryElement<T, U, V> this[T key]
    {
        get
        {
            return GetElement(key);
        }
    }
    
    public ExtendedDictionaryElement<T, U, V> GetElement(T key)
    {
        foreach (var element in _elements)
        {
            if (Equals(element.Key, key))
            {
                return element;
            }
        }

        throw new KeyNotFoundException($"Key '{key}' not found");
    }

    public IEnumerator<ExtendedDictionaryElement<T, U, V>> GetEnumerator()
    {
        return _elements.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

