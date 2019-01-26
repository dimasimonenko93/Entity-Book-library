using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DAL
{
    public interface IDatabaseItem
    {
        void AddToDatabase(IDatabaseItem b);
    }
}
