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
    public partial class FormularioFiltros : Form
    {
        private Filtro? _filtroAtual;
        private readonly DateTime _dataBasePadrao = DateTime.Today.AddDays(-1);
        private readonly DateTime _dataTetoPadrao = DateTime.Today.AddDays(1);

        public FormularioFiltros(Filtro filtro)
        {
            InitializeComponent();
            DefinirValoresNosFiltros(filtro);
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

            radioVilao.Checked = _filtroAtual.EVilao == true;
            radioHeroi.Checked = _filtroAtual.EVilao == false;

            datetimeFiltroDataBase.Value = _filtroAtual.DataBase ?? _dataBasePadrao;
            datetimeFiltroDataTeto.Value = _filtroAtual.DataTeto ?? _dataTetoPadrao;
        }

        private void AoClicarNoButaoResetarLimpaOsFiltros(object sender, EventArgs e)
        {
            _filtroAtual = null;

            radioHeroi.Checked = false;
            radioVilao.Checked = false;

            datetimeFiltroDataBase.Value = _dataBasePadrao;
            datetimeFiltroDataTeto.Value = _dataTetoPadrao;
        }

        private void AoClicarNoButaoAplcarFechaOsFiltros(object sender, EventArgs e)
        {
            ObterFiltros();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
