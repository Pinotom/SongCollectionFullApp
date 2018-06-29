<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="User_Interface.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://bootswatch.com/4/united/bootstrap.min.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.10/css/solid.css" integrity="sha384-HTDlLIcgXajNzMJv5hiW5s2fwegQng6Hi+fN6t5VAcwO/9qbg2YEANIyKBlqLsiT" crossorigin="anonymous">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.10/css/fontawesome.css" integrity="sha384-8WwquHbb2jqa7gKWSoAwbJBV2Q+/rQRss9UXL5wlvXOZfSodONmVnifo/+5xJIWX" crossorigin="anonymous">
    <link href="/css/mystyle.css" rel="stylesheet" />
    <title>Album CRUD Site</title>
</head>
<body>
    <div class="container">
        <div class="spacer"></div>
        <form id="form1" runat="server">
            <section class="row justify-content-center">
                <div class="col-md-4">
                    <h2>Log In:</h2>
                    <div class="card border-primary">
                        <div class="card-header bg-primary">
                            <i class="fas fa-sign-in-alt titel"></i><span class="titel">Meld je hier aan:</span>
                        </div>
                        <div class="card-body bg-light">
                            <div class="form-group">
                                <asp:DropDownList class="form-control" ID="ddlUsers" runat="server"></asp:DropDownList>
                            </div>
                    
                            <asp:Button CssClass="btn btn-outline-primary" ID="btnGoToDetailsPage" runat="server" Text="Log In" OnClick="btnGoToDetailsPage_Click" />
                            
                        </div>
                    </div>
                </div>
            </section>
            


            
        </form>
    </div>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.0/umd/popper.min.js" integrity="sha384-cs/chFZiN24E4KMATLdqdvsezGxaGsi4hLGOzlXwp5UZB1LY//20VyM2taTB4QvJ" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js" integrity="sha384-uefMccjFJAIv6A+rW+L4AHf99KvxDjWSu1z9VI8SKNVmz4sk7buKt/6v9KI65qnm" crossorigin="anonymous"></script>
</body>
</html>
