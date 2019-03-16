using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Models.View_Models.Jazz
{
    public class JazzTables
    {
        public List<JazzTableView> JThursday { get; set; }
        public List<JazzTableView> JFriday { get; set; }
        public List<JazzTableView> JSaturday { get; set; }
        public List<JazzTableView> JSunday { get; set; }

        public JazzTables(List<JazzTableView> thursday, List<JazzTableView> friday, List<JazzTableView> saturday, List<JazzTableView> sunday)
        {
            this.JThursday = thursday;
            this.JFriday = friday;
            this.JSaturday = saturday;
            this.JSunday = sunday;
        }
    }
}