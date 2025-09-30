using System;
namespace seventh_lesson
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
    public class VisibleAttribute : Attribute
    {
        public bool isVisible {  get; }

        public VisibleAttribute(bool isVisible)
        {
            this.isVisible = isVisible;
        }
    }
}
