using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models.Interfaces
{
    interface IBox
    {
        Log Log { get; set; }

        User User { get; set; }
    }
}
