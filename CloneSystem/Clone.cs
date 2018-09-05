using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneVersionSystem.CloneSystem
{
    class Clone : IClone
    {
        public uint ID { get; set; }
        public Stack<LearningCourse> Learned { get; private set; }
        public Stack<LearningCourse> RolledBack { get; private set; }

        public Clone(UInt32 id)
        {
            ID = id;
            Learned = new Stack<LearningCourse>();
            RolledBack = new Stack<LearningCourse>();

            Console.WriteLine("Clone {0} was created!", ID);
        }

        public IClone DoClone()
        {
            // To peform non-reference copying, we need to instantiate new Clone
            // (e.g. implement interface IClonable inside) and copy all the fields
            // including Stacks, repeating this operation for their elements

            // Reference copying
            return (Clone)MemberwiseClone();
        }
    }
}
