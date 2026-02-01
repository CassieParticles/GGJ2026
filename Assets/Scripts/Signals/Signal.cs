using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Signal", menuName = "Signals/Signal", order = 0)]
public class Signal : ScriptableObject
{
    public delegate void SignalFunction();
    
    private List<SignalFunction> signalFunctions = new  List<SignalFunction>();

    public void AddFunction(SignalFunction signalFunction)
    {
        signalFunctions.Add(signalFunction);
    }

    public void RemoveFunction(SignalFunction signalFunction)
    {
        signalFunctions.Remove(signalFunction);
    }

    public void Send()
    {
        foreach (SignalFunction signalFunction in signalFunctions)
        {
            signalFunction();
        }
    }
}
