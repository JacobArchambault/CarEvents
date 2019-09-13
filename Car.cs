using System;
using System.Collections.Generic;
using System.Text;

namespace CarEvents
{
    public class Car
    {
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }
        private bool carIsDead;

        public Car(string name, int maxSp, int currSp)
        {
            PetName = name;
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
        }

        // This delegate works in conjunction with the Car's events.
        public delegate void CarEngineHandler(string msg);

        // This car can send these events.
        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;

        public void Accelerate(int delta)
        {
            // If the car is dead, fire Exploded event.
            if (carIsDead)
            {
                if (Exploded != null)
                    Exploded("Sorry, this car is dead...");
            }
            else
            {
                CurrentSpeed += delta;

                // Almost dead?
                if (10 == MaxSpeed - CurrentSpeed && AboutToBlow != null)
                {
                    AboutToBlow("Careful buddy! Gonna blow!");
                }
                // Still OK!
                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }
        }
    }
}
