using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;
using UnityEngine.UIElements;

public class CarAPI : MonoBehaviour
{
    /**
     * enables a function to use keyboard to trigger car events
     *
     * when set to true, keyboard input can be used to simulate car events.
     * press H to show help in the console.
     */
    public bool EnableKeyboardEventSimulator = false;

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

    /// <summary>
    /// adds a listener for a specific car event identified by `id`.
    /// </summary>
    /// <param name="id">The identifier of the car event to listen for.</param>
    /// <param name="listener">The action to be performed when the event is triggered.</param>
    /// <param name="listenerDescription">An optional description of the listener, used for logging purposes.</param>
    public void Add(CarEventID id, Action<CarEventArgs> listener, string listenerDescription = "")
    {
        if (!eventDict.ContainsKey(id))
        {
            eventDict[id] = delegate { };
        }

        eventDict[id] += listener;

        Debug.Log($"CarAPI\tEvent {id} added from {listenerDescription}");
    }

    /// <summary>
    /// emits a specific car event identified by `id`, executing all associated listeners.
    /// </summary>
    /// <param name="id">The identifier of the car event to emit.</param>
    /// <param name="eventArgs">The arguments for the car event; defaults to an empty instance if not provided.</param>
    public void Emit(CarEventID id, CarEventArgs eventArgs = null)
    {
        // default to an empty CarEventArgs if none is provided
        eventArgs ??= new CarEventArgs();

        if (eventDict.TryGetValue(id, out var action))
        {
            action.Invoke(eventArgs);
        }

        Debug.Log($"CarAPI\tEvent {id} emitted");
    }

    // static to ensure work across different instances
    private static readonly Dictionary<CarEventID, Action<CarEventArgs>> eventDict = new();
    private const string helpMessage =
        @"Emit an Event by keyboard input:
1: ShiftIntoPark
2: ShiftIntoDrive
3: ShiftIntoReverse
4: StartCharging
8: BatteryEmpty
9: BatteryLowPower,
0: BatteryFull,
WSAD: Accelerate, Decelerate, TurnLeft, TurnRight
IKJL: SuddenAccelerate, SuddenDecelerate, SuddenTurnLeft, SuddenTurnRight
";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("CarAPI\tlaunch in current Scene");

        if (EnableKeyboardEventSimulator)
            Debug.Log("CarAPI\t enable Keyboard Event Simulation");
    }

    // Update is called once per frame
    void Update()
    {
        if (EnableKeyboardEventSimulator)
            UpdateKeyboardEventEmulation();
    }

    void UpdateKeyboardEventEmulation()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.LogWarning(helpMessage);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Emit(CarEventID.ShiftIntoPark);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Emit(CarEventID.ShiftIntoDrive);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Emit(CarEventID.ShiftIntoReverse);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Emit(CarEventID.StartCharging);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Emit(CarEventID.BatteryEmpty);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Emit(CarEventID.BatteryLowPower);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Emit(CarEventID.BatteryFull);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Emit(CarEventID.Accelerate);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Emit(CarEventID.Decelerate);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Emit(CarEventID.TurnLeft);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Emit(CarEventID.TurnRight);
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            Emit(CarEventID.SuddenAccelerate);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            Emit(CarEventID.SuddenDecelerate);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            Emit(CarEventID.SuddenTurnLeft);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            Emit(CarEventID.SuddenTurnRight);
        }
    }
}
