using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneVersionSystem.CloneSystem
{
    class CloneSystem
    {
        SortedDictionary<uint, IClone> kazarma = new SortedDictionary<uint, IClone>();

        public void AddClone(IClone clone)
        {
            kazarma.Add(clone.ID, clone);
        }

        public void Learn(uint id, LearningCourse course)
        {
            IClone clone = GetClone(id);
            if (clone == null)
                return;

            if (!HasCourse(clone, course))
            {
                clone.Learned.Push(course);
                clone.RolledBack.Clear();

                Console.WriteLine("Clone {0}: learned course {1}", id, course.ID);
            }
        }

        public void Learn(IClone clone, uint course)
        {
            Learn(clone.ID, new LearningCourse(course));
        }

        public void Rollback(uint id)
        {
            IClone clone = GetClone(id);
            if (clone == null)
                return;

            if (!(clone.Learned.Count == 0))
            {
                clone.RolledBack.Push(clone.Learned.Pop());

                Console.WriteLine("Clone {0}: last course rolledback", id);
            }
            else
            {
                Console.WriteLine("Nothing to rollback");
            }
        }

        public void Rollback(IClone clone)
        {
            Rollback(clone.ID);
        }

        public void Relearn(uint id)
        {
            IClone clone = GetClone(id);
            if (clone == null)
                return;

            if (!(clone.RolledBack.Count == 0))
            {
                clone.Learned.Push(clone.RolledBack.Pop());

                Console.WriteLine("Clone {0}: relearned last rollback", id);
            }
            else
            {
                Console.WriteLine("No rollbacks avaliable");
            }
        }

        public void Relearn(IClone clone)
        {
            Relearn(clone.ID);
        }

        public void Clone(uint id)
        {
            IClone prototype = GetClone(id);
            if (prototype == null)
                return;

            IClone clone = prototype.DoClone();

            clone.ID = GetNextID();

            kazarma.Add(clone.ID, clone);

            Console.WriteLine("Clone {0}: cloned", id);
        }

        public void Clone(IClone clone)
        {
            Clone(clone.ID);
        }

        public void FullCheck(uint id)
        {
            IClone clone = GetClone(id);
            if (clone == null)
                return;

            Console.WriteLine("Clone {0} courses:", id);
            PrintAllCourses(clone);
        }

        public void FullCheck(IClone clone)
        {
            FullCheck(clone.ID);
        }

        public void Check(uint id)
        {
            IClone clone = GetClone(id);
            if (clone == null)
                return;

            if (clone.Learned.Count == 0)
            {
                Console.WriteLine("Clone {0}: is basic", id);
                return;
            }

            Console.WriteLine("Clone {0}: last course is {1}", id, GetLastCourseID(clone));
        }

        public void Check(IClone clone)
        {
            Check(clone.ID);
        }

        private IClone GetClone(uint id)
        {
            if (kazarma.ContainsKey(id))
                return kazarma[id];
            else
            {
                Console.WriteLine("Wrong clone ID");
                return null;
            }
        }

        private bool HasCourse(IClone clone, LearningCourse course)
        {
            foreach(var crs in clone.Learned)
            {
                if (crs.ID == course.ID)
                    return true;
            }
            return false;
        }

        private uint GetNextID()
        {
            if (kazarma.Count == 0)
                return 0;
            return kazarma.Last().Key + 1;
        }

        private void PrintAllCourses(IClone clone)
        {
            if (clone.Learned.Count == 0)
            {
                Console.WriteLine("basic");
                return;
            }

            foreach(var crs in clone.Learned)
            {
                Console.WriteLine(crs.ID);
            }
        }

        private uint GetLastCourseID(IClone clone)
        {
            return clone.Learned.First().ID;
        }

        public void CreateDefaultArmy()
        {
            IClone a = new Clone(GetNextID());
            AddClone(a);
            IClone b = new Clone(GetNextID());
            AddClone(b);
            IClone c = new Clone(GetNextID());
            AddClone(c);

            Learn(a, 1);
            Learn(a, 2);
            Learn(b, 42);
            Learn(c, 1337);

            Rollback(a);
            Clone(b);
        }
    }
}
