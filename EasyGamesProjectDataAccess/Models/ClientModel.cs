using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGamesProjectDataAccess.Models;

public class ClientModel
{
    public int ClientID { get; set; }

    public string? FirstName { get; set; }

    public string? Surname { get; set; }

    public double ClientBalance { get; set; }
}
