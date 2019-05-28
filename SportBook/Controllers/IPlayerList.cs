using Microsoft.AspNetCore.Mvc;
using SportBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBook.Controllers
{
    public interface IPlayerList
    {
        List<User> getAllPlayers();
    }
}
