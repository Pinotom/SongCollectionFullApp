<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailsPage.aspx.cs" Inherits="User_Interface.DetailsPage" %>

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
            <asp:ScriptManager ID="DetailsScriptmanager" runat="server"></asp:ScriptManager>
            <div class="row justify-content-end">
                <asp:Label CssClass="feedback" ID="lblSaveFeedback" runat="server" Text=""></asp:Label>
                <asp:Button CssClass="btn btn-primary" ID="btnSavePreference" runat="server" Text="Save Preference" OnClick="btnSavePreference_Click" />
            </div>
            <div class="row">


                <div class="col-sm-6 pr-2">
                    <asp:UpdatePanel ID="ArtistPanel" runat="server">
                    <ContentTemplate>
                        <h3>Selected artist:</h3>
                        <asp:DropDownList class="form-control" ID="ddlArtists" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlArtists_SelectedIndexChanged"></asp:DropDownList>
                        <div class="small-spacer"></div>
                        <section class="card border-primary">
                            <div class="card-header bg-primary">
                                <i class="fas fa-plus titel" aria-hidden="true"></i> <span class="titel">Add song to artist</span>
                            </div>
                            <div class="card-body bg-light">
                                <div class="form-group">
                                    <label for="txtAddTitle">Title:</label>
                                    <asp:TextBox CssClass="form-control" ID="txtAddTitle" runat="server"></asp:TextBox>                                    
                                </div>
                                <div class="form-group">
                                    <label for="txtAddPrice">Price:</label>
                                    <asp:TextBox CssClass="form-control" ID="txtAddPrice" runat="server" TextMode="Number"></asp:TextBox>                                    
                                </div>
                                <asp:Button CssClass="btn btn-outline-primary" ID="btnAddSong" runat="server" Text="Add Song" OnClick="btnAddSong_Click" />
                                <asp:Label CssClass="feedback" ID="lblAddSongFeedback" runat="server" Text=""></asp:Label>
                            </div>
                        </section>
                        <div class="small-spacer"></div>
                    
                        <section class="card border-primary">
                            <div class="card-header bg-primary">
                                <i class="fas fa-search titel" aria-hidden="true"></i> <span class="titel">Search songs by artist</span>
                            </div>
                            <div class="card-body bg-light">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtSearch" runat="server" placeholder="Optional..."></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Button CssClass="btn btn-outline-primary" ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                </div>
                                <asp:GridView ID="gvSearch" autogeneratecolumns="false" runat="server">
                                    <columns>
                                        <asp:BoundField datafield="Title" headertext="Title"/>
                                        <asp:BoundField datafield="Price" headertext="Price" />
                                    </columns>
                                </asp:GridView>
                            </div>
                        </section>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnAddSong" />
                    </Triggers>
                    </asp:UpdatePanel>
                </div>



                <div class="col-sm-6 pl-2">
                    <asp:UpdatePanel ID="SongPanel" runat="server">
                    <ContentTemplate>
                        <h3>Selected song:</h3>
                        <asp:DropDownList class="form-control" ID="ddlSongs" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSongs_SelectedIndexChanged"></asp:DropDownList>
                        <div class="small-spacer"></div>
                        <section class="card border-primary">
                            <div class="card-header bg-primary">
                                <i class="fas fa-edit titel"></i><span class="titel">Update song</span>
                            </div>
                            <div class="card-body bg-light">
                                <div class="form-group">
                                    <label for="txtUpdateArtist">Artist:</label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlUpdateArtist" runat="server"></asp:DropDownList>                                   
                                </div>
                                <div class="form-group">
                                    <label for="txtUpdateArtist">Title:</label>
                                    <asp:TextBox  CssClass="form-control" ID="txtUpdateTitle" runat="server"></asp:TextBox>                                   
                                </div>
                                <div class="form-group">
                                    <label for="txtUpdatePrice">Price:</label>
                                    <asp:TextBox CssClass="form-control" ID="txtUpdatePrice" runat="server" TextMode="Number"></asp:TextBox>                                   
                                </div>
                                <asp:Button CssClass="btn btn-outline-primary" ID="btnUpdateSong" runat="server" Text="Update Song" OnClick="btnUpdateSong_Click" />
                                <asp:Label CssClass="feedback" ID="lblUpdateSongFeedback" runat="server" Text=""></asp:Label>
                            </div>
                        </section>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnUpdateSong" />
                    </Triggers>
                    </asp:UpdatePanel>
                    <div class="small-spacer"></div>
                    <section class="card border-primary">
                        <div class="card-header bg-primary">
                            <i class="fas fa-trash-alt titel" aria-hidden="true"></i> <span class="titel">Delete song</span>
                        </div>
                        <div class="card-body bg-light">
                                <asp:Button CssClass="btn btn-outline-primary" ID="btnDelete" runat="server" Text="Delete selected song" OnClick="btnDelete_Click" />
                                <asp:Label CssClass="feedback" ID="lblDeleteFeedback" runat="server" Text=""></asp:Label>
                        </div>
                    </section>
                </div>
            </div>



            <div class="small-spacer"></div>
            <div class="row justify-content-sm-center">
                <div class="col-sm-auto">
                    <asp:UpdatePanel ID="OverviewPanel" runat="server">
                    <ContentTemplate>
                    <div class="card border-primary">
                        <div class="card-header bg-primary">
                            <i class="fas fa-table titel" aria-hidden="true"></i> <span class="titel">Overview</span>
                            <asp:Button CssClass="btn btn-outline-light float-right" ID="btnOverview" runat="server" Text="Update Overview" OnClick="btnOverview_Click" />
                        </div>
                        <div class="card-body bg-light">
                            <asp:GridView ID="gvOverview" runat="server"></asp:GridView>
                        </div>
                    </div>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            


            
        </form>
    </div>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.0/umd/popper.min.js" integrity="sha384-cs/chFZiN24E4KMATLdqdvsezGxaGsi4hLGOzlXwp5UZB1LY//20VyM2taTB4QvJ" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js" integrity="sha384-uefMccjFJAIv6A+rW+L4AHf99KvxDjWSu1z9VI8SKNVmz4sk7buKt/6v9KI65qnm" crossorigin="anonymous"></script>
</body>
</html>
