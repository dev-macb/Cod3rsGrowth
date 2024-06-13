using Cod3rsGrowth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class FormFiltros : Form
    {
        private Filtro? _filtroAtual;

        public FormFiltros(Filtro filtro)
        {
            InitializeComponent();
            DefinirValoresNosFiltros(filtro);

            radioHeroi.Checked = filtro.EVilao == false;
            radioVilao.Checked = filtro.EVilao == true;
            datetimeFiltroDataBase.Value = filtro.DataBase ?? DateTime.Today.AddDays(-1);
            datetimeFiltroDataTeto.Value = filtro.DataTeto ?? DateTime.Today.AddDays(1);
        }

        public Filtro ObterFiltros()
        {
            if (_filtroAtual == null) return new Filtro();

            _filtroAtual.EVilao = radioVilao.Checked;
            _filtroAtual.DataBase = datetimeFiltroDataBase.Value;
            _filtroAtual.DataTeto = datetimeFiltroDataTeto.Value;

            return _filtroAtual;
        }

        private void DefinirValoresNosFiltros(Filtro filtro)
        {
            _filtroAtual = filtro;

            if (_filtroAtual.EVilao == true)
            {
                radioVilao.Checked = true;
            }
            else if (_filtroAtual.EVilao == false)
            {
                radioHeroi.Checked = true;
            }
            else
            {
                radioHeroi.Checked = false;
                radioVilao.Checked = false;
            }

            datetimeFiltroDataBase.Value = _filtroAtual.DataBase ?? DateTime.Today.AddDays(-1);
            datetimeFiltroDataTeto.Value = _filtroAtual.DataTeto ?? DateTime.Today.AddDays(1);
        }

        private void AoClicarNoButaoResetarLimpaOsFiltros(object sender, EventArgs e)
        {
            _filtroAtual = null;

            radioHeroi.Checked = false;
            radioVilao.Checked = false;

            datetimeFiltroDataBase.Value = DateTime.Today.AddDays(-1);
            datetimeFiltroDataTeto.Value = DateTime.Today.AddDays(1);
        }

        private void AoClicarNoButaoAplcarFechaOsFiltros(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
