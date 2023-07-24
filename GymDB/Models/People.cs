using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDB.Models
{
    public partial class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Customer { get; set; }
        public string Worker { get; set; }
        public string Subscription { get; set; }
        
        
    }
}
