using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Contracts
{
    public interface IStudent
    {
        int Id { get; }
        string Name { get; }
    }
}
