using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyApplication
{
    class FilePrinter : IPrinter
    {

    private FormView GetMainForm()
        {
            foreach (var form in Application.OpenForms)
            {
                var res = form as FormView;
                if (res != null)
                {
                    return res;
                }
            }
            throw new MissingMemberException("Main Form not found");
        }



        public void Print(int[,] array)
        {
            var mainForm = GetMainForm();
            var numColumns = array.GetUpperBound(0)+1;
            var numRows = array.GetUpperBound(1)+1;
            var path = mainForm.MyTextBox.Text;
            var sb = new StringBuilder();
            for (var j = 0; j < numRows; j++)
            {
                for (var i = 0; i < numColumns; i++)
                {
                    sb.AppendFormat("{0,4}", array[i, j]);
                }
                sb.AppendLine();
            }
            using (var w = new StreamWriter(path)) {
            w.WriteLine(sb.ToString());
            }
        }
    }
}
