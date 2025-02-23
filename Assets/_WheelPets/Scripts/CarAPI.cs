using System;
using System.Collections.Generic;
using UnityEngine;

// fixme CarApi is deprecated
public class CarAPI
{
    /// <summary>
    /// possible event sent from the car to the wheel pet game
    /// </summary>
    public enum Event
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
        RunRedLight,
        FailToStopAtStopSign,
        HitACyclist,
    }

    public class CarEventArgs
        : EventArgs { // todo
    }

    // static to ensure work across different instances
    private static readonly Dictionary<Event, Action<CarEventArgs>> eventDict =
        new();

    /// <summary>
    /// adds a listener for a specific car event identified by `id`.
    /// </summary>
    /// <param name="id">The identifier of the car event to listen for.</param>
    /// <param name="listener">The action to be performed when the event is triggered.</param>
    /// <param name="listenerDescription">An optional description of the listener, used for logging purposes.</param>
    public static void Add(
        Event id,
        Action<CarEventArgs> listener,
        string listenerDescription = ""
    )
    {
        if (!eventDict.ContainsKey(id))
        {
            eventDict[id] = delegate { };
        }

        eventDict[id] += listener;

        if (Debug.isDebugBuild)
        {
            Debug.Log($"CarAPI\tEvent {id} added from {listenerDescription}");
        }
    }

    /// <summary>
    /// emits a specific car event identified by `id`, executing all associated listeners.
    /// </summary>
    /// <param name="id">The identifier of the car event to emit.</param>
    /// <param name="eventArgs">The arguments for the car event; defaults to an empty instance if not provided.</param>
    public static void Emit(Event id, CarEventArgs eventArgs = null)
    {
        // default to an empty CarEventArgs if none is provided
        eventArgs ??= new CarEventArgs();

        if (eventDict.TryGetValue(id, out var action))
        {
            action.Invoke(eventArgs);
        }

        if (Debug.isDebugBuild)
        {
            Debug.Log($"CarAPI\tEvent {id} emitted");
        }
    }
}
