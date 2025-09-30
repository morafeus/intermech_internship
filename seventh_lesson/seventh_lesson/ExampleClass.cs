

namespace seventh_lesson
{
    public class ExampleClass
    {
        private int _exampleVisible;
        private int _exampleInVisible;

        
        public int ExampleVisible 
        {
            [Visible(true)]
            get { return _exampleVisible; }
            [Visible(true)]
            set { _exampleVisible = value; }
        }

        public int ExampleInvisible
        {
            [Visible(false)]
            get { return _exampleInVisible; }
            [Visible(false)]
            set { _exampleInVisible = value; }
        }

        [Visible(true)]
        public void ExampleVisibleMethod()
        {
            ExampleVisible = 0;
        }

        [Visible(false)]
        public void ExampleInvisibleMethod()
        {
            ExampleInvisible = 0;
        }
    }
}
