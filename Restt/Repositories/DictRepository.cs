using Newtonsoft.Json;
using Restt.Context;
using Restt.Models;
using Restt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restt.Repositories
{
    public class DictRepository : IDictRepository
    {
        private readonly RestContext _context;

        public DictRepository(RestContext context)
        {
            _context = context;
        }
        public string GetDict(string name)
        {
            string sql = string.Format("select * from {0}", "Dict" + name);
            var adapter = new SqlDataAdapter(sql, _context.Database.Connection.ConnectionString);
            var ds = new DataSet();
            adapter.Fill(ds);

            string json = JsonConvert.SerializeObject(ds.Tables[0].Rows[0].Table);
            return json;
        }
    }
}
