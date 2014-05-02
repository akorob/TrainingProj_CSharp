using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Settings
    {
        private int _n;
        private int _m;
        private String _path;
		private bool _settingsChanged;

	    public int N
	    {
		    get { return _n; }
		    set { _n = value; }
	    }

	    public int M
	    {
		    get { return _m; }
		    set { _m = value; }
	    }

	    public string Path
	    {
		    get { return _path; }
		    set { _path = value; }
	    }








    }
}
