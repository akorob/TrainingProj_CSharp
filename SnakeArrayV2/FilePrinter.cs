using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace SnakeArray
{
    class FilePrinter : IPrinter
    {
        public String Path { get; set; }

	    public void Print(Model model)
	    {
		    var sb = new StringBuilder();
		    for (var j = 0; j < model.NumRows; j++)
		    {
			    for (var i = 0; i < model.NumColumns; i++)
			    {
				    sb.AppendFormat("{0,4}", model.Array[i, j]);
			    }
			    sb.AppendLine();
		    }
		    try
		    {
			    using (var w = new StreamWriter(Path))
			    {
				    w.WriteLine(sb.ToString());
					MessageBox.Show("Данные успешно сохранены", 
					"Сохранение файла", MessageBoxButtons.OK, MessageBoxIcon.None );
			    }

		    }
		    catch (IOException ex)
		    {
			    MessageBox.Show("Произошла ошибка \n" + ex.ToString(),
				    "Печать в файл", MessageBoxButtons.OK, MessageBoxIcon.Error);
		    }


	    }

    }
}
