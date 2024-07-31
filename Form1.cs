using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poketest
{
    public partial class frmPokemon : Form
    {
        private List<Pokemon> pokeList;
        public frmPokemon()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PokeServices service = new PokeServices();
            pokeList = service.list();
            dgvPokemons.DataSource = pokeList;
            loadImage(pokeList[0].UrlImage);
        }

        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)
        {
            Pokemon selected = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
            loadImage(selected.UrlImage);
        }

        private void loadImage(string image)
        {
            try
            {
                pbxPokemon.Load(image);
            }
            catch (Exception ex)
            {

                pbxPokemon.Load("https://pbs.twimg.com/media/ERPDVqzWAAUwLRl.png");
            }
        }
    }
}
