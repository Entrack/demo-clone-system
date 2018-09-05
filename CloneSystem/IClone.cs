using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneVersionSystem.CloneSystem
{
    interface IClone
    {
        uint ID { get; set; }

        Stack <LearningCourse> Learned { get; }
        Stack <LearningCourse> RolledBack { get; }

        IClone DoClone();
    }
}
