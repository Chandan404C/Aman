<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>QR Code for GPay Payment</title>
    <script>
        // Optional: If you want to handle click events more interactively
        function openUPIApp() {
            window.location.href = "upi://pay?pa=amanagarwal8700-2@okaxis&pn=AmanKumar&am=1&cu=INR&tn=PaymentForGoods";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Scan the QR Code to Pay via Google Pay</h2>
            <asp:Image ID="imgQRCode"  runat="server" CssClass="qrCodeImage"  />
        </div>
    </form>
</body>
</html>
