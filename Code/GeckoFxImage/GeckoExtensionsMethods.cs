using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Gecko;

namespace GeckoExample
{
    public static class GeckoExtensionsMethods
    {
        private static Image ByteArrayToImage( byte[] byteArrayIn )
        {
            MemoryStream ms = new MemoryStream( byteArrayIn );
            Image returnImage = Image.FromStream( ms );
            return returnImage;
        }

        public class JsImage
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public Image Image { get; set; }
        }

        public static Image MakeImage( GeckoWebBrowser browser, JsImage imageInfo )
        {
            var ic = new ImageCreator( browser );
            return ByteArrayToImage( ic.CanvasGetPngImage( (uint)imageInfo.Left, (uint)imageInfo.Top, (uint)imageInfo.Width, (uint)imageInfo.Height ) );
        }

        public static JsImage GetJsImage( this GeckoWebBrowser browser, string elementId )
        {
            var jsImage = new JsImage();
            using ( var context = new AutoJSContext( browser.Window.JSContext ) )
            {
                string js = @"
                    function getElementInfo( elementId )
                    {
	                    var resArr = new Array();
	                    var element = document.getElementById( elementId );
	                    var rect = element.getBoundingClientRect();
	                    resArr.push( rect.top );
	                    resArr.push( rect.right );
	                    resArr.push( rect.bottom );
	                    resArr.push( rect.left );
	                    resArr.push( element.offsetWidth );
	                    resArr.push( element.offsetHeight );
	                    return resArr;
                    }
                    getElementInfo(""" + elementId + @""");";
                string result;
                context.EvaluateScript( js, (nsISupports)browser.Document.DomObject, out result );
                if ( result == "undefined" )
                {
                    return null;
                }
                string[] dataArr = result.Split( ',' );
                jsImage.Top = (int)XmlConvert.ToDouble( dataArr[ 0 ] );
                jsImage.Right = (int)XmlConvert.ToDouble( dataArr[ 1 ] );
                jsImage.Bottom = (int)XmlConvert.ToDouble( dataArr[ 2 ] );
                jsImage.Left = (int)XmlConvert.ToDouble( dataArr[ 3 ] );
                jsImage.Width = (int)XmlConvert.ToDouble( dataArr[ 4 ] );
                jsImage.Height = (int)XmlConvert.ToDouble( dataArr[ 5 ] );
                jsImage.Image = MakeImage( browser, jsImage );
            }
            return jsImage;
        }
    }
}
