/* 
CarAPI define an interface between the pet-game
and the "car" (i.e. the driving sim)

how to use on pet-game side, i.e. 2D side

class Pet: MonoBehavior
{
    private void Start()
    {
        // set up the event listner
        // subscribe to the SuddenAccelerate event
        // link the event with the function GetScared
        CarEvent.add(CarEventID.SuddenAccelerate, GetScared);
    }

    private void GetScared(CarEventArgs eventArgs)
    {
        // play animation of pet getting scared
    }
}


how to use on driving-sims side, i.e. 3D side
class Car: MonoBehavior
{
    private void Update() {
        if (...) {  // when detect a sudden acceleration
            CarEvent.emit(CarEventID.SuddenAccelerate);
        }
    }
}
*/


using System;
using System.Collections.Generic;


namespace CarAPI
{
    public enum CarEventID
    { 
        // Car related event
        ShiftIntoPark,
        ShiftIntoDrive,
        ShiftIntoReverse,
        StartCharging,  // consider StartCharing as another gear

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

    public class CarEventArgs: EventArgs { // TODO
    }

    public static class CarEvent
    {
        private static Dictionary<CarEventID, Action<CarEventArgs>> eventDict =
            new Dictionary<CarEventID, Action<CarEventArgs>>();

        public static void add(CarEventID id, Action<CarEventArgs> listener) {
            if (!eventDict.ContainsKey(id))
            {
                eventDict[id] = delegate {};
            }
            eventDict[id] += listener;
        }

    public static void emit(CarEventID id, CarEventArgs eventArgs = null)
    {
        // default to an empty CarEventArgs if none is provided
        eventArgs ??= new CarEventArgs();

        if (eventDict.TryGetValue(id, out var action))
        {
            action.Invoke(eventArgs);
        }
    }

    }
}