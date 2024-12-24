using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QRCoder;
using System.Drawing;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GenerateQRCode();
        }
    }


    private void GenerateQRCode()
    {
        // Your UPI ID and other payment details
        

        // Generate QR Code
        using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
        {
            string upiUrl = "upi://pay?pa=amanagarwal8700-2@okaxis&pn=AmanKumar&am=1&cu=INR&tn=PaymentForGoods";
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(upiUrl, QRCodeGenerator.ECCLevel.Q);
            using (QRCode qrCode = new QRCode(qrCodeData))
            {
                using (Bitmap qrCodeImage = qrCode.GetGraphic(20))
                {
                    // Convert QR Code to byte array
                    using (MemoryStream ms = new MemoryStream())
                    {
                        qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] byteImage = ms.ToArray();

                        // Display QR Code in Image Control
                        string base64Image = Convert.ToBase64String(byteImage);
                        imgQRCode.ImageUrl = "data:image/png;base64," + base64Image;
                        // Make the image clickable (for mobile UPI app redirection)
                        imgQRCode.Attributes.Add("onclick", "window.location.href='" + upiUrl + "'");

                    }
                }
            }
        }
    }


}