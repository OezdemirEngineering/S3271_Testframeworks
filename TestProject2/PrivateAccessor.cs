
using System.Reflection;

namespace TestProject2;

public static class PrivateAccessorHelper
{
    /// <summary>
    /// Greift auf den Wert eines privaten oder internen Feldes zu.
    /// </summary>
    /// <typeparam name="T">Der erwartete Typ des Wertes.</typeparam>
    /// <param name="instance">Die Instanz, deren Feld gelesen werden soll.</param>
    /// <param name="fieldName">Der Name des Feldes.</param>
    /// <returns>Der Wert des Feldes.</returns>
    public static T GetPrivateField<T>(this object instance, string fieldName)
    {
        var field = instance.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
        if (field is null)
        {
            throw new ArgumentException($"Field '{fieldName}' not found in type '{instance.GetType()}'.");
        }
        return (T)field.GetValue(instance);
    }

    /// <summary>
    /// Setzt den Wert eines privaten oder internen Feldes.
    /// </summary>
    /// <param name="instance">Die Instanz, deren Feld gesetzt werden soll.</param>
    /// <param name="fieldName">Der Name des Feldes.</param>
    /// <param name="value">Der zu setzende Wert.</param>
    public static void SetPrivateField(this object instance, string fieldName, object value)
    {
        var field = instance.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
        if (field == null)
        {
            throw new ArgumentException($"Field '{fieldName}' not found in type '{instance.GetType()}'.");
        }
        field.SetValue(instance, value);
    }

    /// <summary>
    /// Ruft eine private oder interne Methode auf.
    /// </summary>
    /// <typeparam name="T">Der erwartete Rückgabewert der Methode.</typeparam>
    /// <param name="instance">Die Instanz, deren Methode aufgerufen werden soll.</param>
    /// <param name="methodName">Der Name der Methode.</param>
    /// <param name="parameters">Die Parameter für die Methode.</param>
    /// <returns>Der Rückgabewert der Methode.</returns>
    public static T CallPrivateMethod<T>(this object instance, string methodName, params object[] parameters)
    {
        var method = instance.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
        if (method == null)
        {
            throw new ArgumentException($"Method '{methodName}' not found in type '{instance.GetType()}'.");
        }
        return (T)method.Invoke(instance, parameters);
    }
}
