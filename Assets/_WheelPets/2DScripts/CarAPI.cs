/* 
  CarAPI define an interface between the pet-game
  and the "car" (i.e. the driving sim)

  TODO write how to use on both sides
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

        public static void remove_all() {
            foreach (var key in eventDict.Keys.ToList())  // BUG
            {
                eventDict[key] = delegate {};  // reset the action to an empty delegate
            }
        }

        public static void emit(CarEventID id, CarEventArgs eventArgs)
        {
            if (eventDict.TryGetValue(id, out var action))
            {
                action.Invoke(eventArgs);
            }
        }
    }
}