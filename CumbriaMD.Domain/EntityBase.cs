using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CumbriaMD.Domain
{
	/// <summary>
    /// Layer supertype for all entity classes
    /// </summary>
    public abstract class EntityBase
    {
        public virtual int Id { get; set; }
    }
}       

