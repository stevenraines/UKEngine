using System;
using System.Reflection;

namespace UKEngine.Attributes
{

    public class NavigableAttribute : Attribute
    {

        protected bool _navigable = true;

        public NavigableAttribute(bool navigable)
        {
            _navigable = navigable;
        }

        public bool Navigable
        {
            get { return _navigable; }
        }
    }

}