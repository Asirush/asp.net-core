using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Lesson3.Lib
{
    public class RoomService
    {
        Model1 db = new Model1();
        public bool AddRoomProperties(RoomProperty roomProp)
        {
            try
            {
                db.RoomProperty.Add(roomProp);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
