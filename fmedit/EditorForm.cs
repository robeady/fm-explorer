using FMScoutFramework.Core;
using FMScoutFramework.Core.Entities.InGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fmedit
{
    public partial class EditorForm : Form
    {
        FMCore fm;
        Player player;

        public EditorForm()
        {
            InitializeComponent();

            foreach (var t in new[] {
                typeof(Player),
                typeof(ActualPerson), 
                typeof(PlayerAttributes), 
                typeof(PersonAttributes), 
                typeof(Contract), 
                typeof(JobAttributes), 
                typeof(PreferredMoves),
                typeof(RoleRatings)
            }) {
                TypeDescriptor.AddAttributes(t, new TypeConverterAttribute(typeof(ExpandableObjectConverter)));
            }
        }

        private void playerUidTextBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(playerUidTextBox.Text, out int playerUid))
            {
                player = fm.Players.Where(p => p.UID == playerUid).FirstOrDefault();
                propertyGrid.SelectedObject = player;
                RefreshUI();
            }
        }

        private void EditorForm_Load(object sender, EventArgs e)
        {
            fm = new FMCore();
            fm.LoadData();

            RefreshUI();
        }

        private void saveAttributesButton_Click(object sender, EventArgs e)
        {
            player.Attributes.Save();
            RefreshUI();
        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            RefreshUI();
        }

        private void RefreshUI()
        {
            propertyGrid.Refresh();
            saveAttributesButton.Enabled = player != null && player.Attributes.isDirty;
        }
    }
}
