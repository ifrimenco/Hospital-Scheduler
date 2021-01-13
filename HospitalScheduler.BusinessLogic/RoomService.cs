using HospitalScheduler.DataAccess;
using HospitalScheduler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalScheduler.BusinessLogic
{
    public class RoomService : BaseService  
    {
        public RoomService(UnitOfWork unitOfWork)
           : base(unitOfWork)
        {
        }

        public IEnumerable<Room> GetAll()
        {
            var rooms = UnitOfWork.Rooms.Get().OrderBy(e => e.Name);
            //rooms.Sort();
            return rooms;
        }

        public string GetFloor(string roomName)
        {
            if (roomName == "Not Set")
            {
                return "Not Set";
            }

            
            int floor;

            if(!int.TryParse(roomName, out floor))
            {
                return "Unknown";
            }

            floor /= 100;

            if (floor == 0)
            {
                return "Ground Floor";
            }

            return floor.ToString();
        }
        public bool Add(Room room)
        {
            if (UnitOfWork.Rooms.Get().Where(s => s.Name == room.Name).Any())
            {
                return false;
            }

            UnitOfWork.Rooms.Insert(room);
            UnitOfWork.SaveChanges();
            return true;
        }

        public void Remove(int id)
        {
            var room = UnitOfWork.Rooms.Get().FirstOrDefault(e => e.Id == id); 
            if (room == null)
            {
                return;
            }
            var appointments = UnitOfWork.Appointments.Get().Where(a => a.Room.Id == room.Id);

            foreach (var appointment in appointments)
            {
                UnitOfWork.Appointments.Delete(appointment);
            }


            UnitOfWork.Rooms.Delete(room);
            UnitOfWork.SaveChanges();
        }
    }
}
