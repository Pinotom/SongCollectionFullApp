using System;
using System.Collections.Generic;
using System.Data;
using DAL;

namespace User_Interface
{
    public partial class DetailsPage : System.Web.UI.Page
    {
        private SongDAL _songDAL = new SongDAL();
        private string selectedArtist;
        private string selectedSong;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                selectedArtist = ddlArtists.SelectedValue;
                selectedSong = ddlSongs.SelectedValue;
            }
            ResetFeedbackLabels();
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (!DetailsScriptmanager.IsInAsyncPostBack)
            {
                FillDDLs();
                ReloadSelection();
                SetUpdateCard();
            }

            if (!IsPostBack)
            {
                InitialSetup();
            }
        }

        protected void ResetFeedbackLabels()
        {
            lblUpdateSongFeedback.Text = "";
            lblAddSongFeedback.Text = "";
            lblDeleteFeedback.Text = "";
            lblSaveFeedback.Text = "";
        }

        protected void FillDDLs()
        {
            FillArtistDDL();
            FillSongDDL();
            FillUpdateArtistDDL();
        }

        protected void InitialSetup()
        {
            ApplyPreferences();
            SetUpdateCard();
            SetSearchCard();
            FillOverview();
        }

        protected void FillArtistDDL()
        {
            _songDAL = new SongDAL();
            List<Artist> artists = _songDAL.GetAllArtists();
            artists.Sort();
            ddlArtists.DataSource = artists;
            ddlArtists.DataTextField = "Performer";
            ddlArtists.DataValueField = "ArtistID";
            ddlArtists.DataBind();
        }

        protected void FillSongDDL()
        {
            _songDAL = new SongDAL();
            List<SongCollection> songs = _songDAL.GetAllSongs();
            songs.Sort();
            ddlSongs.DataSource = songs;
            ddlSongs.DataTextField = "Title";
            ddlSongs.DataValueField = "SongID";
            ddlSongs.DataBind();
        }

        protected void FillUpdateArtistDDL()
        {
            ddlUpdateArtist.DataSource = ddlArtists.DataSource;
            ddlUpdateArtist.DataTextField = "Performer";
            ddlUpdateArtist.DataValueField = "ArtistID";
            ddlUpdateArtist.DataBind();
        }

        protected void ReloadSelection()
        {
            if (ddlArtists.Items.FindByValue(selectedArtist) != null)
            {
                ddlArtists.SelectedValue = selectedArtist;
            }
            ddlArtists.SelectedValue = selectedArtist;
            if(ddlSongs.Items.FindByValue(selectedSong) != null)
            {
                ddlSongs.SelectedValue = selectedSong;
            }
        }

        protected void FillOverview()
        {
            _songDAL = new SongDAL();
            DataTable overviewTable = _songDAL.Overview();
            DataView overviewView = overviewTable.DefaultView;
            overviewView.Sort = "Performer asc";
            gvOverview.DataSource = overviewView;
            gvOverview.DataBind();
        }

        protected void ApplyPreferences()
        {
            _songDAL = new SongDAL();
            Preference preference = _songDAL.GetPreference(Request.QueryString["user"]);
            if (preference.Performer != -1 && ddlArtists.Items.FindByValue(preference.Performer.ToString()) != null)
            {
                ddlArtists.SelectedValue = preference.Performer.ToString();
            }
            if (preference.Title != -1 && ddlSongs.Items.FindByValue(preference.Title.ToString()) != null)
            {
                ddlSongs.SelectedValue = preference.Title.ToString();
            }
            else
            {
                lblSaveFeedback.Text = "Your saved song doesn't exist.";
            }
            
        }

        protected void SetUpdateCard()
        {
            int currentSongID = int.Parse(ddlSongs.SelectedValue);
            _songDAL = new SongDAL();
            SongCollection song = _songDAL.GetSong(currentSongID);
            ddlUpdateArtist.SelectedValue = song.ArtistID.ToString();
            txtUpdateTitle.Text = song.Title;
            txtUpdatePrice.Text = song.Price.ToString();
        }

        protected void SetSearchCard()
        {
            int artistID = int.Parse(ddlArtists.SelectedValue);
            string zoekterm = txtSearch.Text;
            _songDAL = new SongDAL();
            List<SongCollection> resultaat = _songDAL.SearchByPerformer(artistID, zoekterm);
            gvSearch.DataSource = resultaat;
            gvSearch.DataBind();
        }

        protected void ddlArtists_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            SetSearchCard();
        }

        protected void ddlSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetUpdateCard();
        }

        protected void btnAddSong_Click(object sender, EventArgs e)
        {
            if (txtAddTitle.Text == "" || txtAddPrice.Text == "")
            {
                lblAddSongFeedback.Text = "Fill in all fields!";
                return;
            }

            int artistID = int.Parse(ddlArtists.SelectedValue);
            string title = txtAddTitle.Text;
            int price = int.Parse(txtAddPrice.Text);

            _songDAL = new SongDAL();
            int newID = _songDAL.AddSong(artistID, title, price);
            if ( newID != 0)
            {
                selectedSong = newID.ToString();
                lblAddSongFeedback.Text = "Addition success!";
            }
            else
            {
                lblAddSongFeedback.Text = "Addition failed!";
            }
        }

        protected void btnUpdateSong_Click(object sender, EventArgs e)
        {
            if (txtUpdateTitle.Text == "" || txtUpdatePrice.Text == "")
            {
                lblUpdateSongFeedback.Text = "No empty fields!";
                return;
            }

            int songID = int.Parse(ddlSongs.SelectedValue);
            string title = txtUpdateTitle.Text;
            int artistID = int.Parse(ddlUpdateArtist.SelectedValue);
            int price = int.Parse(txtUpdatePrice.Text);
            _songDAL = new SongDAL();
            if (_songDAL.UpdateSong(songID, title, artistID, price))
            {
                lblUpdateSongFeedback.Text = "Update success!";
            }
            else
            {
                lblUpdateSongFeedback.Text = "Update failed!";
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SetSearchCard();            
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int songID = int.Parse(ddlSongs.SelectedValue);

            _songDAL = new SongDAL();
            if (_songDAL.DeleteSong(songID))
            {
                lblDeleteFeedback.Text = "Delete success!";
            }
            else
            {
                lblDeleteFeedback.Text = "Delete failed!";
            }
        }

        protected void btnSavePreference_Click(object sender, EventArgs e)
        {
            string userID = Request.QueryString["user"];
            int performer = int.Parse(ddlArtists.SelectedValue);
            int title = int.Parse(ddlSongs.SelectedValue);
            _songDAL = new SongDAL();
            if (_songDAL.SavePreference(userID, performer, title))
            {
                lblSaveFeedback.Text = "Preference saved!";
            }
            else
            {
                lblSaveFeedback.Text = "Save failed!";
            }

        }

        protected void btnOverview_Click(object sender, EventArgs e)
        {
            FillOverview();
        }
    }
}