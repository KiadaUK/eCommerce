﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CumbriaMD.Domain
{
    public class Money
    {
        protected Money() { }

        public Money(decimal amount)
        {
            Amount = amount;
        }

        public virtual decimal Amount { get; set; }

        public override string ToString()
        {
            return String.Format("{0:c}", Amount);
        }
    }
}
    

