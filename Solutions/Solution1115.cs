using System;
using System.Threading;

namespace Solutions
{
    public class FooBar
    {
        private readonly int n;
        private readonly AutoResetEvent resetEvent1;
        private readonly AutoResetEvent resetEvent2;

        public FooBar(int n)
        {
            this.n = n;
            resetEvent1 = new AutoResetEvent(false);
            resetEvent2 = new AutoResetEvent(true);
        }

        public void Foo(Action printFoo)
        {
            for (var i = 0; i < n; i++)
            {
                resetEvent2.WaitOne();
                // printFoo() outputs "foo". Do not change or remove this line.
                printFoo();
                resetEvent1.Set();
            }
        }

        public void Bar(Action printBar)
        {
            for (var i = 0; i < n; i++)
            {
                resetEvent1.WaitOne();
                // printBar() outputs "bar". Do not change or remove this line.
                printBar();
                resetEvent2.Set();
            }
        }
    }
}