using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core
{
	public interface IEntity
	{
        public int Id { get; set; }
    }
	public abstract class Entity : IEntity
	{
		public int Id { get; set; }
	}
}
