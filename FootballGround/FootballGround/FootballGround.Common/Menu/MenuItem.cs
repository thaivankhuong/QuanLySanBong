using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGround.Common.MenuHelper
{
    public class MenuItem
    {
        public string Icon { get; set; }
        public string Link { get; set; }
        public bool IsChild
        {
            get
            {
                return (Childs.Count > 0 && Childs != null);
            }
        }
        public string Title { get; set; }
        public List<MenuItem> Childs { get; set; }
        public string Controller
        {
            /// Home/Index
            get
            {
                if (Link.Equals("#"))
                {
                    return "#";
                }
                else
                {
                    return  Link.Substring(0, Link.IndexOf('/'));
                 
                }

            }
        }
        public string Action
        {
            get
            {
                if(Link.Equals("#") && Link.Length < 2)
                {
                    return "";
                }
                return (Link.Substring(Link.IndexOf('/')+1)) ;
            }
        }

        public MenuItem()
        {
            this.Childs = new List<MenuItem>();
        }
    }
}
