using System;
namespace OA.Data.Domain
{
    public class LessonVideoRoomConnections:BaseEntity
    {
        public string Connection_Id { get; set; }

        public string  User_Name { get; set; }
        public Guid Room_Id { get; set; }
        public LessonVideoRoomConnections()
        {

        }

        public LessonVideoRoomConnections(string Id,string name)
        {
            Connection_Id = Id;
            User_Name = name;
        }
        public virtual LessonVideoRoom LessonVideoRoom { get; set; }


    }
}
