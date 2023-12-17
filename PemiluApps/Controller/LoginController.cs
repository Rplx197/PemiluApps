using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemiluApps.Controller
{
    public class LoginController
    {
        public void TogglePasswordVisibility(TextBox textBox,CheckBox checkBox)
        {
            if (checkBox.Checked)
            {
                textBox.UseSystemPasswordChar = false;
            }
            else
            {
                textBox.UseSystemPasswordChar = true;
            }
        }

    }
}
