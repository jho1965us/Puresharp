﻿using System;

namespace Puresharp.Confluence
{
    public sealed partial class Advice
    {
        public partial class Boundary
        {
            static internal partial class Advanced
            {
                public partial class After
                {
                    public partial class Returning
                    {
                        public partial class Volatile : Advice.Boundary.IFactory
                        {
                            private Func<Action<object, object[], object>> m_Action;

                            public Volatile(Func<Action<object, object[], object>> action)
                            {
                                this.m_Action = action;
                            }

                            public Advice.IBoundary Create()
                            {
                                return new Advice.Boundary.Advanced.After.Returning(this.m_Action());
                            }
                        }
                    }
                }
            }
        }
    }
}