using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DJanel.Muebles.WFApplication.Forms.Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        #region Métodos

        #endregion

        #region Eventos
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnLogin.Focus();
                BtnLogin_Click(sender, e);
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                //BannerTextInfo placeholderUsuario = bannerTextProvider.GetBannerText(UserAccountControl);
                //placeholderUsuario.Text = "Usuario";
                //placeholderUsuario.Visible = true;
                //placeholderUsuario.Mode = BannerTextMode.EditMode;

                //BannerTextInfo placeholderPassword = bannerTextProvider.GetBannerText(UserPasswordControl);
                //placeholderPassword.Text = "Contraseña";
                //placeholderPassword.Visible = true;
                //placeholderPassword.Mode = BannerTextMode.EditMode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UsuarioControl_Enter(object sender, EventArgs e)
        {
            if (UsuarioControl.Text == "Usuario")
            {
                UsuarioControl.Text = "";
            }
        }

        private void UsuarioControl_Leave(object sender, EventArgs e)
        {
            if(UsuarioControl.Text == "")
            {
                UsuarioControl.Text = "Usuario";
            }
        }

        private void PasswordControl_Enter(object sender, EventArgs e)
        {
            if (PasswordControl.Text == "Password")
            {
                PasswordControl.Text = "";
            }
        }

        private void PasswordControl_Leave(object sender, EventArgs e)
        {
            if (PasswordControl.Text == "")
            {
                PasswordControl.Text = "Password";
            }
        }
    }
}
