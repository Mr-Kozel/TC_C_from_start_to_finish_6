using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TrackerLibrary.Data
{
    public class MyappContext : DbContext
    {
        public MyappContext(DbContextOptions<MyappContext> options) : base(options)
        {

        }
    }
}
