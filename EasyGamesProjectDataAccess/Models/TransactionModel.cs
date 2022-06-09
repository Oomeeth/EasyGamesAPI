using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGamesProjectDataAccess.Models;

public class TransactionModel
{
    public int TransactionID { get; set; }

    public double Amount { get; set; }

    public int TransactionTypeID { get; set; }

    public int ClientID { get; set; }

    public string? Comment { get; set; }
}
