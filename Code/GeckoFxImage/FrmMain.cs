#region Using

using System;
using System.Drawing;
using System.Windows.Forms;
using Gecko;

#endregion

namespace GeckoFxImage
{
    public partial class FrmMain : Form
    {
        private readonly GeckoWebBrowser _webBrowser;
        private readonly CaptchaEnter _captcha;

        public FrmMain()
        {
            // инициализация Xulrunner
            Xpcom.Initialize( Application.StartupPath + "\\xulrunner\\" );
            this.InitializeComponent();
            this._webBrowser = new GeckoWebBrowser
            {
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom,
                Width = this.Width,
                Height = this.Height - 75,
                Top = 0,
                AutoSize = false
            };
            // маскируемся под Firefox 22
            GeckoPreferences.User[ "general.useragent.override" ] =
                "Mozilla/5.0 (Windows NT 6.1; rv:22.0) Gecko/20130405 Firefox/22.0";
            var frm = new Form();
            frm.Controls.Add( this._webBrowser );
            this._captcha = new CaptchaEnter( this._webBrowser );
        }

        private void DisEnObjs()
        {
            this.btnEnter.Enabled = !this.btnEnter.Enabled;
            this.btnGetNew.Enabled = !this.btnGetNew.Enabled;
        }

        private async void btnEnter_Click( object sender, EventArgs e )
        {
            this.DisEnObjs();
            if ( await this._captcha.InputCaptcha( this.tbInput.Text ) )
            {
                MessageBox.Show( "Капча введена верно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
            else
            {
                MessageBox.Show( "Капча введена неверно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            this.DisEnObjs();
        }

        private async void btnGetNew_Click( object sender, EventArgs e )
        {
            this.DisEnObjs();
            Image image = await this._captcha.GetCaptcha();
            this.pbImage.Image = image;
            this.pbImage.Refresh();
            this.DisEnObjs();
            this.tbInput.Focus();
        }
    }
}