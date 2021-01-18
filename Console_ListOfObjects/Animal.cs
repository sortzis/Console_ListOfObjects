using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_ListOfObjects
{
    class Animal
    {

        public enum Diet
        {
            none,
            omnivore,
            herbivore,
            carnivore
        }

        #region FIELDS

        private string _name;
        private int _leg;
        private Diet _diets;
        private bool _status;

        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Leg
        {
            get { return _leg; }
            set { _leg = value; }
        }

        public Diet Diets
        {
            get { return _diets; }
            set { _diets = value; }
        }

        private bool Status
        {
            get { return _status; }
            set { _status = value; }
        }

        #endregion
    }
}
