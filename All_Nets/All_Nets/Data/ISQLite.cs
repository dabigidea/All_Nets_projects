using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace All_Nets.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
