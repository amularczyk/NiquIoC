using NiquIoC.Attributes;

namespace NiquIoC.Test
{
    internal class Bar
    {
    }

    internal interface IFoo
    {
        Bar Bar { get; }
    }

    internal class Foo : IFoo
    {
        public Foo()
        {
        }

        public Foo(Bar bar)
        {
            Bar = bar;
        }

        public Bar Bar { get; }
    }

    internal class FooAttr : IFoo
    {
        [DependencyConstrutor]
        public FooAttr(Bar bar, string text)
        {
            Bar = bar;
            Text = text;
        }

        public string Text { get; private set; }
        public Bar Bar { get; }
    }

    internal class FooTwoAttr : IFoo
    {
        [DependencyConstrutor]
        public FooTwoAttr(Bar bar)
        {
            Bar = bar;
        }

        [DependencyConstrutor]
        public FooTwoAttr()
        {
        }

        public Bar Bar { get; }
    }

    internal class FooCycle
    {
        public FooCycle(BarCycle bar)
        {
            Bar = bar;
        }

        public BarCycle Bar { get; private set; }
    }

    internal class BarCycle
    {
        public BarCycle(FooCycle foo)
        {
            Foo = foo;
        }

        public FooCycle Foo { get; private set; }
    }

    internal interface IFooProp
    {
        Bar Bar { get; set; }
    }

    internal class FooProp : IFooProp
    {
        [DependencyProperty]
        public Bar Bar { get; set; }
    }

    internal interface IFooManyProp
    {
        Bar Bar { get; set; }

        IFooProp FooProp { get; set; }
    }

    internal class FooManyProp : IFooManyProp
    {
        [DependencyProperty]
        public Bar Bar { get; set; }

        [DependencyProperty]
        public IFooProp FooProp { get; set; }
    }

    internal interface IFooPropNoSet
    {
        Bar Bar { get; }
    }

    internal class FooPropNoSet : IFooPropNoSet
    {
        public FooPropNoSet()
        {
            Bar = null;
        }

        [DependencyProperty]
        public Bar Bar { get; }
    }
}