using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory.Quick_Access
{
    public class QuickAccessItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Image Icon { get; set; }
        public Type FormType { get; set; }
        public Action OpenForm { get; set; }
    }
}
