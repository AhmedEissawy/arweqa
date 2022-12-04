using System;
using System.Collections.Generic;

namespace OA.Data.Domain
{
    public class LessonVideoRoom:BaseEntity
    {

        public LessonVideoRoom()
        {
            Connections = new HashSet<LessonVideoRoomConnections>();
        }

        public Guid LessonId { get; set; }
        public string RoomId { get; set; }
        public int Attenendence { get; set; }
        public DateTime LiveDate { get; set; }
        public virtual Lesson Lesson { get; set; }
        public virtual ICollection<LessonVideoRoomConnections> Connections { get; set; }
        
    }
}
