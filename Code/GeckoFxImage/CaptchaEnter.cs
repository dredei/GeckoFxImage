#region Using

using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gecko;

#endregion

namespace GeckoFxImage
{
    public class CaptchaEnter
    {
        private readonly GeckoWebBrowser _browser;
        private readonly Timer _loadingTimer; // таймер загрузки
        private bool _loading; // указывает на статус загрузки

        public CaptchaEnter( GeckoWebBrowser browser )
        {
            this._browser = browser;
            this._loadingTimer = new Timer { Interval = 4000 };
            this._loadingTimer.Tick += this._loadingTimer_Tick;
        }

        private void _loadingTimer_Tick( object sender, EventArgs e )
        {
            this._loadingTimer.Stop();
            this._loading = false;
        }

        /// <summary>
        /// Ожидает загрузки страницы
        /// </summary>
        private async Task WaitForLoading()
        {
            while ( this._loading )
            {
                await TaskEx.Delay( 200 );
            }
        }

        /// <summary>
        /// Загружает указанную страницу и ждет завершения загрузки
        /// </summary>
        /// <param name="url">Url страницы</param>
        private async Task Navigate( string url )
        {
            this._loading = true;
            this._browser.Navigate( url );
            this._loadingTimer.Start();
            await this.WaitForLoading();
        }

        /// <summary>
        /// Возвращает изображение с капчей
        /// </summary>
        /// <returns></returns>
        public async Task<Image> GetCaptcha()
        {
            await this.Navigate( "http://www.unitedway-pdx.org/contact-files/captcha/test/captcha_test.php" );
            GeckoExtensionsMethods.JsImage jsImage = this._browser.GetJsImage( "si_image" );
            return jsImage == null ? null : jsImage.Image;
        }

        /// <summary>
        /// Вводит капчу и проверяет корректность ввода
        /// </summary>
        /// <param name="input">Текст капчи</param>
        /// <returns>Возвращает значение, указывающее на корректность ввода</returns>
        public async Task<bool> InputCaptcha( string input )
        {
            // получаем элемент (input) с указанным id
            var inputEl = this._browser.Document.GetElementById( "code" );
            if ( inputEl == null )
            {
                return false;
            }
            // устанавливаем input'у текст, который ввел пользователь
            inputEl.SetAttribute( "value", input );
            // выбираем первый input, значение (value) которого равно submit
            var btnEl =
                this._browser.Document.GetElementsByTagName( "input" )
                    .FirstOrDefault( b => b.GetAttribute( "value" ) == "submit" );
            if ( btnEl == null )
            {
                return false;
            }
            btnEl.Click();
            await TaskEx.Delay( 2500 );
            // выбираем первый p, который содержить указанный текст
            var pEl =
                this._browser.Document.GetElementsByTagName( "p" )
                    .FirstOrDefault( p => p.InnerHtml.Contains( "Test Passed." ) );
            // если такой элемент получен - тест пройден успешно
            return pEl != null;
        }
    }
}