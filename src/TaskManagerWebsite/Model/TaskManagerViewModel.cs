using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerWebsite.Model
{
    public class TaskManagerViewModel
    {
        public IEnumerable<TaskDto> Tasklist { get; set; }

        public IEnumerable<UserDto> Userlist { get; set; }

        public IEnumerable<AssignmentDto> Assignmentlist { get; set; }

    }
}
