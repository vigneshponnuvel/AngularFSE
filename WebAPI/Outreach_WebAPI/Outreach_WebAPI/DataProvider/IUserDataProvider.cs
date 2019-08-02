using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Outreach_WebAPI.Models;

namespace Outreach_WebAPI.DataProvider
{
    public interface IUserDataProvider
    {        
        TMstrUser Login(TMstrUser login);
    }
}
