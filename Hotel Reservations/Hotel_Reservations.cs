using System;

namespace Hotel_Reservations
{
    public class Hotel
    {
        // Each cell in array represents how many rooms are occupied for each day in a year
        // Size of array is usually 365
        private readonly int[] occupiedRooms;
        // Number of rooms in hotel
        private readonly int numberOfRooms = 0;
        public Hotel(int rooms)
        {
            // 365 days in a year
            occupiedRooms = new int[365];
            numberOfRooms = rooms;
        }

        public bool ReserveRoom(int from, int to)
        {
            // Checking for edge casses
            if (from < 0 || from > 365 || to < 0 || to > 365 || from > to)
            {
                return false;
            }

            // We itterate trough array of days and we increment numbers of rooms
            for (int i = from; i <= to; i++)
            {
                occupiedRooms[i]++;
                // If any day in year needs more rooms than we can offer we decline that reservation
                if (occupiedRooms[i] > numberOfRooms)
                {
                    // Decrementing all elements in array that we incremented in this try (Undo this try)
                    for (int j = i; j >= from; j--)
                    {
                        occupiedRooms[j]--;
                    }
                    // Decline reservation
                    return false;
                }
            }
            // Reserving rooms and confirming reservation
            return true;
        }

        static void Main(string[] args)
        {
        }
    }
}
