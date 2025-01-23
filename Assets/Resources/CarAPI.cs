using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CarAPI", menuName = "Scriptable Objects/CarAPI1")]
public class CarAPI1 : ScriptableObject
{
    /// <summary>
    /// possible event sent from the car to the wheel pet game
    /// </summary>
    public enum CarEventID
    {
        // Car related event
        ShiftIntoPark,
        ShiftIntoDrive,
        ShiftIntoReverse,
        StartCharging, // consider StartCharing as another gear

        // car battery related events
        BatteryEmpty,
        BatteryLowPower,
        BatteryFull,

        // events during driving
        // can be used to invoke pet animation
        Accelerate,
        Decelerate,
        TurnLeft,
        TurnRight,
        SuddenAccelerate,
        SuddenDecelerate,
        SuddenTurnLeft,
        SuddenTurnRight,

        // driver behavior events, used for point scoring
        // TODO this is just some example, will be changed
        RunRedLight,
        FailToStopAtStopSign,
        HitACyclist,
    }

    public class CarEventArgs
        : EventArgs { // TODO
    }

    private static readonly Dictionary<CarEventID, Action<CarEventArgs>> eventDict = new();

    public void Add(CarEventID id, Action<CarEventArgs> listener)
    {
        if (!eventDict.ContainsKey(id))
        {
            eventDict[id] = delegate { };
        }

        eventDict[id] += listener;

        // FIXME need test
        Debug.Log($"Event {id} added");
    }

    public static void Emit(CarEventID id, CarEventArgs eventArgs = null)
    {
        // default to an empty CarEventArgs if none is provided
        eventArgs ??= new CarEventArgs();

        if (eventDict.TryGetValue(id, out var action))
        {
            action.Invoke(eventArgs);
        }

        // FIXME need test
        Debug.Log($"Event {id} emitted");
    }
}
