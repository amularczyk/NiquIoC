using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleContainer;

namespace SampleContainer.Test
{
    #region Upper Intermediate Container

    class BarUIC
    {
        public BarUIC()
        {
        }
    }

    interface IFooUIC
    {
        BarUIC Bar { get; }
    }

    class FooUIC : IFooUIC
    {
        public BarUIC Bar { get; private set; }

        public FooUIC()
        {
        }

        public FooUIC(BarUIC bar)
        {
            Bar = bar;
        }
    }

    class FooAttrUIC : IFooUIC
    {
        public BarUIC Bar { get; private set; }
        public string Text { get; private set; }

        [DependencyConstrutor]
        public FooAttrUIC(BarUIC bar, string text)
        {
            Bar = bar;
            Text = text;
        }
    }

    class FooTwoAttrUIC : IFooUIC
    {
        public BarUIC Bar { get; private set; }

        [DependencyConstrutor]
        public FooTwoAttrUIC(BarUIC bar)
        {
            Bar = bar;
        }

        [DependencyConstrutor]
        public FooTwoAttrUIC()
        {
        }
    }

    class FooCycleUIC
    {
        public BarCycleUIC Bar { get; private set; }

        public FooCycleUIC(BarCycleUIC bar)
        {
            Bar = bar;
        }
    }

    class BarCycleUIC
    {
        public FooCycleUIC Foo { get; private set; }

        public BarCycleUIC(FooCycleUIC foo)
        {
            Foo = foo;
        }
    }

    interface IFooPropUIC
    {
        BarUIC Bar { get; set;  }
    }

    class FooPropUIC : IFooPropUIC
    {
        [DependencyProperty]
        public BarUIC Bar { get; set; }

        public FooPropUIC()
        {
        }
    }

    interface IFooManyPropUIC
    {
        BarUIC Bar { get; set; }

        IFooPropUIC FooPropUIC { get; set; }
    }

    class FooManyPropUIC : IFooManyPropUIC
    {
        [DependencyProperty]
        public BarUIC Bar { get; set; }
        
        [DependencyProperty]
        public IFooPropUIC FooPropUIC { get; set; }

        public FooManyPropUIC()
        {
        }
    }

    interface IFooPropNoSetUIC
    {
        BarUIC Bar { get; }
    }

    class FooPropNoSetUIC : IFooPropNoSetUIC
    {
        private BarUIC _bar;

        [DependencyProperty]
        public BarUIC Bar 
        {
            get
            {
                return _bar;
            }
        }

        public FooPropNoSetUIC()
        {
            _bar = null;
        }
    }

    #endregion Intermediate Container

    #region Intermediate Container

    class BarIC
    {
        public BarIC()
        {
        }
    }

    interface IFooIC
    {
        BarIC Bar { get; }
    }

    class FooIC : IFooIC
    {
        public BarIC Bar { get; private set; }

        public FooIC()
        {
        }

        public FooIC(BarIC bar)
        {
            Bar = bar;
        }
    }

    class FooAttrIC : IFooIC
    {
        public BarIC Bar { get; private set; }
        public string Text { get; private set; }

        [DependencyConstrutor]
        public FooAttrIC(BarIC bar, string text)
        {
            Bar = bar;
            Text = text;
        }
    }

    class FooTwoAttrIC : IFooIC
    {
        public BarIC Bar { get; private set; }

        [DependencyConstrutor]
        public FooTwoAttrIC(BarIC bar)
        {
            Bar = bar;
        }

        [DependencyConstrutor]
        public FooTwoAttrIC()
        {
        }
    }

    class FooCycleIC
    {
        public BarCycleIC Bar { get; private set; }

        public FooCycleIC(BarCycleIC bar)
        {
            Bar = bar;
        }
    }

    class BarCycleIC
    {
        public FooCycleIC Foo { get; private set; }

        public BarCycleIC(FooCycleIC foo)
        {
            Foo = foo;
        }
    }

    #endregion Intermediate Container

    #region Beginner Container

    class FooBC : IFooBC
    {
    }

    interface IFooBC
    {
    }

    #endregion Beginner Container
}
