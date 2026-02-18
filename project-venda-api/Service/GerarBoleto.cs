
using ACBrLib.Boleto;
using ACBrLib.Core.Boleto;
using ACBrLib.Core;
using project_venda_api.Models;
using project_venda_api.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace project_venda_api.Services
{
    public class BoletoService
    {
        private readonly AppDbContext _context;

        public BoletoService(AppDbContext context)
        {
            _context = context;
        }

        public string GerarBoleto(Guid tituloId)
        {
            var tituloDb = _context.Titulos
            .Include(t => t.Cedente)
            .Include(t => t.Sacado)
            .FirstOrDefault(t => t.Id == tituloId);

            if (tituloDb == null)
                throw new Exception("Título não encontrado.");


            var iniPath = Path.Combine(AppContext.BaseDirectory, "ACBrBoleto.ini");
            var boleto = new ACBrBoleto(iniPath);

            try
            {
                // ===============================
                // LOG
                // ===============================
                boleto.Config.Principal.LogNivel = NivelLog.logNormal;
                boleto.Config.Principal.LogPath = Path.Combine(AppContext.BaseDirectory, "Logs");

                // ===============================
                // CONFIGURAÇÃO DO PDF / LOGO
                // ===============================

                Console.WriteLine(File.Exists(@"C:\cnesistemas\LogosBoleto\001.bmp"));


                boleto.ConfigGravarValor(
                    ACBrSessao.BoletoBancoFCFortesConfig,
                    "DirLogo",
                    @"C:\cnesistemas\LogosBoleto\001.png"
                );

                boleto.ConfigGravarValor(
                    ACBrSessao.BoletoBancoFCFortesConfig,
                    "MostrarPreview",
                    0
                );

                boleto.ConfigGravarValor(
                    ACBrSessao.BoletoBancoFCFortesConfig,
                    "MostrarProgresso",
                    0
                );

                boleto.ConfigGravar();

                // ===============================
                // BANCO DO BRASIL - PRODUÇÃO
                // ===============================
                boleto.Config.Banco.Numero =  1; // 001
                boleto.Config.Banco.LayoutVersaoArquivo = 240;
                boleto.Config.Banco.LayoutVersaoLote = 240;
                boleto.Config.Banco.TipoCobranca = ACBrTipoCobranca.cobBancoDoBrasil;

                // ===============================
                // CEDENTE
                // ===============================
                boleto.Config.Cedente.Nome = tituloDb.Cedente.Nome;
                boleto.Config.Cedente.CNPJCPF = tituloDb.Cedente.CNPJCPF;
                boleto.Config.Cedente.Logradouro = tituloDb.Cedente.Logradouro;
                boleto.Config.Cedente.NumeroRes = tituloDb.Cedente.Numero;
                boleto.Config.Cedente.Bairro = tituloDb.Cedente.Bairro;
                boleto.Config.Cedente.Cidade = tituloDb.Cedente.Cidade;
                boleto.Config.Cedente.UF = tituloDb.Cedente.UF;
                boleto.Config.Cedente.CEP = tituloDb.Cedente.CEP;
                boleto.Config.Cedente.Telefone = tituloDb.Cedente.Telefone;

                // DADOS BANCÁRIOS
                boleto.Config.Cedente.Agencia = tituloDb.Cedente.Agencia;
                boleto.Config.Cedente.AgenciaDigito = tituloDb.Cedente.AgenciaDigito;
                boleto.Config.Cedente.Conta = tituloDb.Cedente.Conta;
                boleto.Config.Cedente.ContaDigito = tituloDb.Cedente.ContaDigito;
                boleto.Config.Cedente.Convenio = tituloDb.Cedente.Convenio;
                boleto.Config.Cedente.CodigoCedente = tituloDb.Cedente.CodigoCedente;
                boleto.Config.Cedente.Modalidade = tituloDb.Cedente.Modalidade;
                boleto.Config.Cedente.TipoCarteira =  ACBrTipoCarteira.tctSimples;
                boleto.Config.Cedente.TipoDocumento = ACBrTipoDocumento.Tradicional;
                boleto.Config.Cedente.TipoInscricao = ACBrPessoa.pJuridica;
                boleto.Config.Cedente.IdentDistribuicao = IdentDistribuicao.tbClienteDistribui;

                // PIX opcional
                boleto.Config.Cedente.ChavePIX = tituloDb.Cedente.ChavePIX;
                boleto.Config.Cedente.TipoChavePIX = TipoChavePIX.tchCNPJ;

                boleto.LimparLista();

                // ===============================
                // TÍTULO
                // ===============================
                var titulo = new ACBrLib.Boleto.Titulo
                {
                    NumeroDocumento = tituloDb.NumeroDocumento,
                    CarteiraEnvio = CarteiraEnvio.tceCedente,
                    NossoNumero = tituloDb.NossoNumero,
                    Carteira = tituloDb.Carteira,

                    ValorDocumento = tituloDb.ValorDocumento,// 1642.00m,
                    ValorMoraJuros = tituloDb.ValorMoraJuros, // 0.33m,
                    PercentualMulta = tituloDb.PercentualMulta,// 2,

                    DataDocumento = tituloDb.DataDocumento, // DateTime.Now,
                    DataProcessamento = tituloDb.DataProcessamento, // DateTime.Now,
                    Vencimento = tituloDb.Vencimento, // DateTime.Now.AddDays(5),

                    Especie = tituloDb.Especie, // "DM",
                    EspecieMod = tituloDb.EspecieMod, // "R$",
                    LocalPagamento = "PAGAR PREFERENCIALMENTE NAS AGÊNCIAS DO BANCO DO BRASIL",

                    Instrucao1 = tituloDb.Instrucao1, // "Após vencimento cobrar multa de 2%",
                    Instrucao2 = tituloDb.Instrucao2, //"Cobrar juros de R$ 0,33 por dia"
                };

                // ===============================
                // SACADO
                // ===============================
                titulo.Sacado.NomeSacado = tituloDb.Sacado.Nome;
                titulo.Sacado.CNPJCPF = tituloDb.Sacado.CNPJCPF;
                titulo.Sacado.Logradouro = tituloDb.Sacado.Logradouro;
                titulo.Sacado.Numero = tituloDb.Sacado.Numero;
                titulo.Sacado.Bairro = tituloDb.Sacado.Bairro;
                titulo.Sacado.Cidade = tituloDb.Sacado.Cidade;
                titulo.Sacado.UF = tituloDb.Sacado.UF;
                titulo.Sacado.CEP = tituloDb.Sacado.CEP;
                titulo.Sacado.Email = tituloDb.Sacado.Email;

                boleto.IncluirTitulos(titulo);

                if (boleto.TotalTitulosLista() == 0)
                    throw new Exception("Nenhum título incluído.");

                // ===============================
                // GERAÇÃO DO PDF
                // ===============================
                string pastaPDF = @"C:\cnesistemas\boletos\";
                Directory.CreateDirectory(pastaPDF);

                boleto.SetDiretorioArquivo(pastaPDF, "boleto_bb");
                boleto.GerarPDF();

                return Path.Combine(pastaPDF, "boleto_bb.pdf");
            }
            finally
            {
                boleto.Dispose();
            }
        }
    }
}